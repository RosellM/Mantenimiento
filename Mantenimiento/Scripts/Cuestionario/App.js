(function () {
    var app = angular.module('MotorCuestionarios', ['ngRoute', 'ngMessages', 'cuestionario-directives', 'configuracionService', 'instrumentacionService', 'ui.bootstrap']);

    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/Final', { templateUrl: '/Cuestionario/Final' })
            .when('/', { templateUrl: '/Cuestionario/Cuestionario' })
        .otherwise({ redirectTo: '/' })
        ;
    });

    app.controller('CuestionarioController', ['$http', '$scope', 'gestorConfiguracion', 'dialogoService', function ($http, $scope, gestorConfiguracion, dialogoService) {
        var cuestionario = this;
        cuestionario.configuracion = {};
        cuestionario.datos = [];

        //Init function
        var cuestionarioController = function () {
            cuestionario.configuracion = gestorConfiguracion.obtieneConfiguracion();

            //Preguntamos si desea continuar.
            if (cuestionario.configuracion.esCuestionarioNuevo) {
                cargaPreguntas();
            }
            else {
                confirmarProgreso();
            }
        };

        //Confirma si desea continuar llenando el cuestionario.
        var confirmarProgreso = function () {
            //Configuracion del modal default.
            var configuracionDialogo = dialogoService.creaConfiguracion();

            //Especifico.
            configuracionDialogo.Titulo = 'Tiene un cuestionario en progreso.';
            configuracionDialogo.Mensaje = '¿Desea continuar contestando? (Si selecciona Cancelar borrará el progreso guardado)';

            //Mostrar dialogo.
            var promise = dialogoService.mostrarDialogo(configuracionDialogo);

            //Promesa
            promise.result.then(function (respuesta) {//Value
                if (respuesta.resultado == 'ok') {
                    cargaPreguntas();
                }
                else if (respuesta.resultado == 'cancel') {
                    $http.delete('/api/Preguntas/' + cuestionario.configuracion.IdCuestionario).success(function (data) {
                        cargaPreguntas();
                    }).error(function (data, status, header, config) {
                        errorService.mostrarError(data);
                    });
                }
            }, function () {//Rechazado
                debugger;
            });
        }

        //Carga las preguntas desde el servidor.
        var cargaPreguntas = function () {
            $http.get('/api/Cuestionario/' + cuestionario.configuracion.IdCuestionario).success(function (data) {
                cuestionario.datos = data;

                //Evento para notificar que se cargaron preguntas.
                $scope.$broadcast('OnCuestionarioCargado', cuestionario.datos);
            }).error(function (data, status, header, config) {
                errorService.mostrarError(data);
            });
        };

        //Recibe notificacion cuando se contestaron las preguntas.
        $scope.$on('OnCuestionarioContestado', function (event, data) {
            //cuestionario.datos = [];
            cargaPreguntas();
        });

        //Init call
        cuestionarioController();

    }]);

    app.controller('PreguntasController', ['$http', '$scope', '$location', 'gestorConfiguracion', 'errorService', function ($http, $scope, $location, gestorConfiguracion, errorService) {
        var preguntas = this;

        //Mantiene la lista de preguntas.
        preguntas.Lista = [];

        //Mantiene IdCuestionario, lista de resspuesta, accion(1: Siguiente, 2: Anterior).
        preguntas.Respuesta = {};
        preguntas.Respuesta.IdCuestionario = null;
        preguntas.Respuesta.Action = 0;

        //Mantiene la lista de respuestas.
        preguntas.Respuesta.Respuestas = [];

        //Enviar formulario con las respuestas
        this.enviarRespuestas = function (eventArgs) {
            //Validamos que se valido el formulario.
            if (!$scope.mainForm.$valid) {
                return;
            }
            //Asignamos accion
            preguntas.Respuesta.Action = eventArgs.action;
            $scope.$broadcast('OnObtieneRespuestas', preguntas.Respuesta.Respuestas);

            $http.post('/api/Preguntas/', preguntas.Respuesta).success(function (data, status, header, config) {
                preguntas.limpiaDatos();
                $scope.$emit('OnCuestionarioContestado', null);
            }).error(function (data, status, header, config) {
                errorService.mostrarError(data);
            });
        };

        //Limpia datos de los vm actuales.
        this.limpiaDatos = function () {
            //Borramos las respuestas.
            preguntas.Respuesta.Respuestas = [];

            //Borramos action
            preguntas.Respuesta.Action = 0;

            //Borramos preguntas.
            preguntas.Lista = [];
        };

        //Carga la configuracion.
        this.estableceConfiguracion = function () {
            var parametros = gestorConfiguracion.obtieneConfiguracion();
            preguntas.Respuesta.IdCuestionario = parametros.IdCuestionario;
        };

        //Valida preguntas recibidas.
        var validaPreguntas = function (listaPreguntas) {
            if (listaPreguntas.length < 1) {
                $location.path('/Final');
            }
        };

        //Evento que recibe el listado de preguntas.
        $scope.$on('OnCuestionarioCargado', function (event, data) {
            preguntas.estableceConfiguracion();
            $http.get('/api/Preguntas/' + data.IdCuestionario).success(function (listaPreguntas) {

                var resultadoValidacion = validaPreguntas(listaPreguntas);

                if (!resultadoValidacion) {
                    preguntas.Lista = listaPreguntas;
                }
                
            }).error(function (data, status, header, config) {
                errorService.mostrarError(data);
            });

        });
    }]);

    app.controller('FinalController', ['$window', 'gestorConfiguracion', function ($window, gestorConfiguracion) {
        var vm = this;
        vm.configuracion = {};
        //Init
        finalController = function () {
            vm.configuracion = gestorConfiguracion.obtieneConfiguracion();
        };

        finalController();

    }]);

})();


/*
            
*/