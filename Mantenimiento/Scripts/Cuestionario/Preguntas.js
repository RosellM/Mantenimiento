(function () {
    var app = angular.module('cuestionario-directives', ['respuestasService', 'ngSanitize', 'ui.bootstrap']);

    app.directive("preguntaBoleana", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaBoleana",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "boleana"
        };
    }]);

    app.directive("preguntaBoleanaDependiente", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaBoleanaDependiente",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;
                this.datos.Dependientes = [];

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "boleana"
        };
    }]);

    app.directive("preguntaBoleanaComentario", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaBoleanaComentario",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;
                this.datos.Dependientes = [];


                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "boleana"
        };
    }]);

    app.directive("preguntaAbierta", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaAbierta",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "abierta"
        };
    }]);

    app.directive("preguntaNumerica", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaNumerica",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "abierta"
        };
    }]);

    app.directive("preguntaFecha", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaFecha",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.formats = ['dd/MM/yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
                $scope.format = $scope.formats[0];

                $scope.open = function ($event) {
                    $event.preventDefault();
                    $event.stopPropagation();

                    $scope.opened = true;
                };

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "abierta"
        };
    }]);

    app.directive("preguntaOpcionMultiple", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaOpcionMultiple",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.algunSeleccionado = function (Respuestas) {
                    for (var respuesta in Respuestas) {
                        var item = Respuestas[respuesta];
                        if (item.Seleccionado)
                            return true;
                    }
                    return false;
                }

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "omultiple"
        };
    }]);

    app.directive("preguntaLink", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaLink",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "link"
        };
    }]);

    app.directive("preguntaListaVerificacion", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaListaVerificacion",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "verificacion"
        };
    }]);

    app.directive("preguntaTexto", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaTexto",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "texto"
        };
    }]);

    app.directive("preguntaListaVerificacionDependiente", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaListaVerificacionDependiente",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;
                this.datos.Dependientes = [];

                //Metodo que valida si se ha seleccionado el dependiente.
                $scope.dependienteSeleccionado = function (RespuestaDependiente) {
                    var Preguntas = $scope.datos.PreguntasAnidadas;
                    for (var pregunta in Preguntas) {
                        var pregunta = Preguntas[pregunta];

                        if (pregunta.RespuestaUsuario == RespuestaDependiente) {
                            return true;
                        }
                    }
                    return false;
                }

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "verificacion"
        };
    }]);

    app.directive("preguntaListaVerificacionComentario", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaListaVerificacionComentario",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;
                this.datos.Dependientes = [];

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "verificacion"
        };
    }]);

    app.directive("preguntaFormulario", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaFormulario",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                this.datos = $scope.datos;

                $scope.formats = ['dd/MM/yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
                $scope.format = $scope.formats[0];

                $scope.open = function ($event, pregunta) {
                    $event.preventDefault();
                    $event.stopPropagation();
                    pregunta.opened = true;
                };

                // Disable weekend selection
                $scope.disabled = function (date, mode) {
                    return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
                };

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "formulario"
        };
    }]);

    app.directive("preguntaCargaArchivo", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaCargarArchivo",
            scope: {
                datos: '=',
                configuracion: '='
            },
            controller: function ($scope, $log, contructorRespuestas) {

                var vm = this;
                vm.datos = $scope.datos;
                vm.configuracion = $scope.configuracion;

                vm.data = new FormData();

                //Indica la información del cuestionario.
                vm.informacionCuestionario = {};

                //Indica si hay algun error.
                vm.error = null;

                //Indica si está cargando algun archivo.
                vm.estaCargando = false;

                //Indica si hay algun archivo existente
                //vm.datos.ArchivoExistente = false

                //Mantiene la relación de archivos.
                //vm.datos.archivos = null;

                //Carga archivo
                $scope.cargaArchivo = function (pregunta) {
                    if (document.getElementById('archivoCarga').files.length < 1)
                        return;

                    vm.estaCargando = true;

                    vm.agregaInformacionCuestionario(pregunta);

                    $http.post('/api/ArchivosAdjuntos/', vm.data, {
                        transformRequest: angular.identity,
                        headers: { 'Content-Type': undefined }
                    }).success(function (data, status, header, config) {
                        vm.estaCargando = false;
                        pregunta.ArchivoExistente = true;
                    }).error(function (data, status, header, config) {
                        vm.error = "Ha ocurrido un error: " + data.statusText;
                    });

                };

                //Borrar archivo
                $scope.borraArchivo = function (pregunta) {
                    vm.estaCargando = true;

                    $http.put('/api/ArchivosAdjuntos/' + vm.datos.IdPregunta, vm.obtieneIdentificadores(pregunta))
                        .success(function (data, status, header, config) {
                        vm.estaCargando = false;
                        pregunta.Archivos = null;
                        pregunta.ArchivoExistente = false;
                        vm.data = new FormData();
                    }).error(function (data, status, header, config) {
                        vm.error = "Ha ocurrido un error: " + data.statusText;
                    });
                };

                //Valida que exista un archio ya cargado
                $scope.validaArchivoAdjunto = function () {
                    var result = false;
                    if (vm.datos.Archivos != null && vm.datos.Archivos.length > 0) {
                        result = true;
                    }
                    return result;
                };

                //Agrega información para el post de carga de archivo multipart/form-data.
                vm.agregaInformacionCuestionario = function (pregunta) {
                    var fileInputElement = document.getElementById('archivoCarga');

                    vm.data.append('IdCuestionario', vm.configuracion.toString());
                    vm.data.append('IdPregunta', pregunta.IdPregunta.toString());
                    vm.data.append('file', fileInputElement.files[0]);

                    pregunta.Archivos = vm.generaArchivos(fileInputElement);
                };

                //Genera a información del cuestionario
                vm.obtieneIdentificadores = function (pregunta) {
                    var datos = {};

                    var nuevaRespuesta = contructorRespuestas.generaNuevaRespuesta(pregunta.IdPregunta);

                    datos.IdCuestionario = vm.configuracion;
                    datos.Respuestas = [];

                    //Agrega una nueva respuesta.
                    datos.Respuestas.push(nuevaRespuesta);

                    return datos;
                };

                //Carga información de los archivos de fileInputElement.files
                vm.generaArchivo = function (file) {
                    var archivo = {};

                    archivo.NombreArchivo = file.name;
                    archivo.Tamano = file.size;

                    return archivo;
                };

                //Carga informacion de los archivos de element
                vm.generaArchivos = function (fileInputElement) {
                    var archivos = [];

                    for(var i = 0; i < fileInputElement.files.length; i++){
                        var file = fileInputElement.files[i];
                        var archivo = vm.generaArchivo(file);
                        archivos.push(archivo);
                    }

                    return archivos;
                };

                $scope.formats = ['dd/MM/yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
                $scope.format = $scope.formats[0];

                $scope.open = function ($event, pregunta) {
                    $event.preventDefault();
                    $event.stopPropagation();
                    pregunta.opened = true;
                };

                // Disable weekend selection
                $scope.disabled = function (date, mode) {
                    return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
                };

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "carga"
        };
    }]);

    app.directive("preguntaGenerarArchivo", ['$http', function ($http) {
        return {
            restrict: "E",
            templateUrl: "/Cuestionario/PreguntaGenerarArchivo",
            scope: {
                datos: '='
            },
            controller: function ($scope, contructorRespuestas) {
                var vm = this;
                vm.datos = $scope.datos;
                vm.identificadorArchivo = null;
                vm.error = null;
                vm.urlDownloadFile = "/GeneraDocumento/Details/";
                vm.submitted = false;

                $scope.generarArchivo = function () {
                    vm.submitted = true;
                    if (vm.validaEntrada(vm.datos)) {
                        var respuestas = contructorRespuestas.construyeRespuesta(vm.datos);

                        $http.post('/Api/GeneraDocumento', respuestas)
                            .success(function (data, status, header, config) {
                                vm.identificadorArchivo = data;
                                document.getElementById('linkDownload').href = vm.urlDownloadFile + data;
                                document.getElementById('linkDownload').click();
                            }).error(function (data, status, header, config) {
                                vm.error = data;
                            });
                    }
                };



                vm.validaEntrada = function (datos) {
                    return $scope.preguntaAnidadaForm.$valid;
                };

                $scope.$on('OnObtieneRespuestas', function (event, data) {
                    var respuesta = contructorRespuestas.construyeRespuesta($scope.datos);
                    data.push(respuesta);
                });
            },
            controllerAs: "formulario"
        };
    }]);

    /* Directives Util */
    app.directive("archivoCargado", function () {
        return {
            restrict: "A",
            require: "ngModel",
            link: function (scope, element, attributes, ngModel) {
                ngModel.$validators.archivoCargado = function (modelValue) {
                    return modelValue
                }
            }
        };
    });

})();