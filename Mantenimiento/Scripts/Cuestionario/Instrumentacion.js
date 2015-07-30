(function () {
    var app = angular.module('instrumentacionService', ['ui.bootstrap']);
    //Servicio que muestra mensajes de error en pantalla.
    app.factory('errorService', ['$modal', function ($modal) {
        //Metodo que recibe el error y lo muestra.
        var mostrarError = function (error) {
            //Crea y muestra una nueva instancia de modal.
            var modalInstance = $modal.open({
                templateUrl: '/Cuestionario/Error',
                controller: 'VentanaErrorController as ventanaError',
                size: 'sm',
                resolve: {
                    error: function () {
                        return error;
                    }
                }
            });

            //Resultado del dialogo.
            modalInstance.result.then(function () {
                $scope.selected = '';
            }, function () {
                $log.info('Error: ' + new Date());
            });
        };

        //Metodos expuestos.
        return {
            mostrarError: mostrarError
        };
    }]);

    //Controller modal de error ($modalInstance, specifico)
    app.controller('VentanaErrorController', function ($scope, $modalInstance, error) {
        var vm = this;
        //Mantiene el objeto de error.
        vm.error = error;

        //Metodo de aceptación.
        this.ok = function () {
            $modalInstance.dismiss('ok');
        };
    });

    //Servicio que muestra dialogos de confirmación.
    app.factory('dialogoService', ['$modal', function ($modal) {
        //Metodo que recibe la configuracion y muestra el modal.
        var mostrarDialogo = function (configuracion) {
            //Crea y muestra una nueva instancia de modal.
            var modalInstance = $modal.open({
                templateUrl: '/Cuestionario/Dialogo',
                controller: 'DialogoController as dialogo',
                backdrop: 'static',
                size: 'sm',
                resolve: {
                    configuracion: function () {
                        return configuracion;
                    }
                }
            });


            //Resultado del dialogo.
            return modalInstance;
            /*modalInstance.result.then(function () {
                $scope.selected = '';
            }, function () {
                $log.info('Error: ' + new Date());
            });*/
        };

        //Genera una instancia de configuracion de dialogo
        var creaConfiguracion = function () {
            var config = {};

            config.Titulo = "Confirmacion.";
            config.Mensaje = "Mensaje.";
            config.Ok = { Texto: 'Aceptar', Visible: true };
            config.Cancel = { Texto: 'Cancelar', Visible: true };

            return config;
        };


        //Metodos expuestos.
        return {
            mostrarDialogo: mostrarDialogo,
            creaConfiguracion: creaConfiguracion
        };
    }]);

    //Controller modal de dialogos de confirmación.
    app.controller('DialogoController', function ($scope, $modalInstance, configuracion) {
        var vm = this;
        //Mantiene el objeto de configuracion.
        vm.configuracion = configuracion;

        //Metodo de aceptación.
        this.ok = function () {
            $modalInstance.close({ resultado: 'ok' });
        };

        //Metodo de cancelar.
        this.cancel = function () {
            $modalInstance.close({ resultado: 'cancel' });
        };
    });



})();


/*
            
*/
