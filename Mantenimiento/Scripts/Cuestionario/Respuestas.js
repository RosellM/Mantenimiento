(function () {
    var app = angular.module('respuestasService', []);

    app.factory('contructorRespuestas', function () {
        //Genera una nueva respuesta para la seleccion del usuario.
        var generaNuevaRespuesta = function (IdPregunta) {
            var nuevaRespuesta = {};
            nuevaRespuesta.IdPregunta = IdPregunta;
            nuevaRespuesta.seleccionUsuario = {};
            nuevaRespuesta.RespuestasAnidadas = [];

            return nuevaRespuesta;
        };

        //Contruye el diccionario con la seleccion del usuario.
        var construyeRespuesta = function (datosPregunta) {
            var respuesta = null;

            switch (datosPregunta.TipoPregunta) {
                case 1: //Boleana
                    respuesta = construyeRespuestaBoleana(datosPregunta);
                    break;
                case 2: //Boleana Comentario
                    respuesta = construyeRespuestaBoleanaDependiente(datosPregunta);
                    break;
                case 3: //Boleana Dependiente
                    respuesta = construyeRespuestaBoleanaDependiente(datosPregunta);
                    break;
                case 4: //Lista de verificacion
                    respuesta = construyeRespuestaListaVerificacion(datosPregunta);
                    break;
                case 5: //Lista de verificacion comentario
                    respuesta = construyeRespuestaListaVerificacionComentario(datosPregunta);
                    break;
                case 6: //Lista de verificacion dependiente
                    respuesta = construyeRespuestaListaVerificacionDependientes(datosPregunta);
                    break;
                case 7: //Formulario
                    respuesta = construyeRespuestaFormulario(datosPregunta);
                    break;
                case 8: //Opcion Multiple
                    respuesta = construyeRespuestaOpcionMultiple(datosPregunta);
                    break;
                case 9: //Generar documento
                    respuesta = construyeRespuestaGenerarArchivo(datosPregunta);
                    break;
                case 10: //Archivo adjunto
                    respuesta = construyeRespuestaAdjuntarArchivo(datosPregunta);
                    break;
                case 11: //Link
                    respuesta = construyeRespuestaLink(datosPregunta);
                    break;
                case 12: //Abierta
                    respuesta = construyeRespuestaAbierta(datosPregunta);
                    break;
                case 13: //Numerica
                    respuesta = construyeRespuestaAbierta(datosPregunta);
                    break;
                case 14: //Fecha
                    respuesta = construyeRespuestaAbierta(datosPregunta);
                    break;
                case 15: //Texto
                    respuesta = construyeRespuestaTexto(datosPregunta);
                    break;
                case 17: //Archivo adjunto simple
                    respuesta = construyeRespuestaAdjuntarArchivoSimple(datosPregunta);
                    break;
                default:
                    throw "Invalid Operation";
                    break;
            }

            return respuesta;
        };


        //Construye seleccion de usuario de una pregunta boleana.
        var construyeRespuestaBoleana = function (datosPregunta) {
            var nuevaRespuesta = generaNuevaRespuesta(datosPregunta.IdPregunta);

            //Iteramos para agregar datos de la seleccion de usuario.
            for (var respuesta in datosPregunta.Respuestas) {
                if (respuesta == datosPregunta.RespuestaUsuario) {
                    nuevaRespuesta.seleccionUsuario[respuesta] = datosPregunta.Respuestas[respuesta];
                }
            }
            return nuevaRespuesta;

        };

        //Construye selección de usuario de una pregunta boleana dependiente.
        var construyeRespuestaBoleanaDependiente = function (datosPregunta) {
            var nuevaRespuesta = construyeRespuestaBoleana(datosPregunta);

            //Iteramos por las preguntas dependientes
            for (var respuestaDependiente in datosPregunta.RespuestasDependientes) {
                respuestaDependiente = datosPregunta.RespuestasDependientes[respuestaDependiente];
                var nuevaRespuestaDependiente = construyeRespuestaAbierta(respuestaDependiente);
                nuevaRespuesta.RespuestasAnidadas.push(nuevaRespuestaDependiente);
            }

            return nuevaRespuesta;
        };

        //Construye selección de usuario de una pregunta abierta.
        var construyeRespuestaAbierta = function (datosPregunta) {
            var nuevaRespuesta = generaNuevaRespuesta(datosPregunta.IdPregunta);

            nuevaRespuesta.seleccionUsuario[datosPregunta.Respuesta.Key] = datosPregunta.Respuesta.Value;

            return nuevaRespuesta;
        };

        //Construye selección de usuario de una pregunta opcion multiple.
        var construyeRespuestaOpcionMultiple = function (datosPregunta) {
            var nuevaRespuesta = generaNuevaRespuesta(datosPregunta.IdPregunta);

            for (var respuesta in datosPregunta.Respuestas) {
                if (datosPregunta.Respuestas[respuesta].Seleccionado) {
                    nuevaRespuesta.seleccionUsuario[respuesta] = datosPregunta.Respuestas[respuesta].Texto;
                }
            }

            return nuevaRespuesta;
        };

        //Construye seleccion de usuario de una pregunta opcion multiple.
        var construyeRespuestaLink = function (datosPregunta) {
            return construyeRespuestaAbierta(datosPregunta);
        };

        //Construye seleccion de usuario de una pregunta de verificacion simple.
        var construyeRespuestaVerificacionSimple = function (datosPregunta) {
            var nuevaRespustaVerificacionSimple = generaNuevaRespuesta(datosPregunta.IdPregunta);

            for (var respuestas in datosPregunta.Respuestas) {
                if (respuestas == datosPregunta.RespuestaUsuario) {
                    nuevaRespustaVerificacionSimple.seleccionUsuario[respuestas] = datosPregunta.Respuestas[respuestas];
                }
            }
            return nuevaRespustaVerificacionSimple;
        };

        //Construye seleccion de usuario de una pregunta de lista de verificación.
        var construyeRespuestaListaVerificacion = function (datosPregunta) {
            var respuesta = generaNuevaRespuesta(datosPregunta.IdPregunta);

            //Crea la seleccion de preguntas anidadas.
            for (var preguntaKey in datosPregunta.PreguntasAnidadas) {
                var pregunta = datosPregunta.PreguntasAnidadas[preguntaKey];
                var nuevaRespuestaVerificacionSimple = construyeRespuestaVerificacionSimple(pregunta);
                respuesta.RespuestasAnidadas.push(nuevaRespuestaVerificacionSimple);
            }

            return respuesta;
        };

        //Construye seleccion de usuario de una pregunta de texto.
        var construyeRespuestaTexto = function (datosPregunta) {
            var nuevaRespuesta = generaNuevaRespuesta(datosPregunta.IdPregunta);

            nuevaRespuesta.seleccionUsuario[datosPregunta.Respuesta.Key] = null;

            return nuevaRespuesta;
        };

        var construyeRespuestaListaVerificacionDependientes = function (datosPregunta) {
            //var respuestas = [];
            var respuesta = construyeRespuestaListaVerificacion(datosPregunta);

            //Iteramos por las preguntas dependientes
            for (var respuestaDependienteKey in datosPregunta.RespuestasDependientes) {
                var respuestaDependiente = datosPregunta.RespuestasDependientes[respuestaDependienteKey];

                var nuevaRespuesta = construyeRespuestaAbierta(respuestaDependiente);

                respuesta.RespuestasAnidadas.push(nuevaRespuesta);
            }

            return respuesta;
        };

        var construyeRespuestaListaVerificacionComentario = function (datosPregunta) {
            var respuesta = construyeRespuestaListaVerificacionDependientes(datosPregunta);
            return respuesta;
        };

        var construyeRespuestaFormulario = function (datosPregunta) {
            var nuevaRespuesta = generaNuevaRespuesta(datosPregunta.IdPregunta);
            for (var preguntaAnidadaKey in datosPregunta.PreguntasAnidadas) {
                try {
                    var preguntaAnidada = datosPregunta.PreguntasAnidadas[preguntaAnidadaKey];

                    var nuevaRespuestaAnidada = construyeRespuesta(preguntaAnidada);
                    nuevaRespuesta.RespuestasAnidadas.push(nuevaRespuestaAnidada);
                }
                catch (ex) {
                    throw ex;
                }
            }
            return nuevaRespuesta;
        };

        var construyeRespuestaAdjuntarArchivoSimple = function (datosPregunta) {
            var nuevaRespuesta = generaNuevaRespuesta(datosPregunta.IdPregunta);

            //Generamos datos del archivo
            for (var archivoKey in datosPregunta.Archivos) {
                var archivo = datosPregunta.Archivos[archivoKey];
                nuevaRespuesta.seleccionUsuario[archivo.Tamano] = archivo.NombreArchivo;
            }

            return nuevaRespuesta;
        };

        var construyeRespuestaAdjuntarArchivo = function (datosPregunta) {

            var nuevaRespuesta = generaNuevaRespuesta(datosPregunta.IdPregunta);

            //Iteramos por las preguntas anidadas
            for (var preguntaAnidadaKey in datosPregunta.PreguntasAnidadas) {
                try {
                    var preguntaAnidada = datosPregunta.PreguntasAnidadas[preguntaAnidadaKey];

                    var nuevaRespuestaAnidada = construyeRespuesta(preguntaAnidada);
                    nuevaRespuesta.RespuestasAnidadas.push(nuevaRespuestaAnidada);
                }
                catch (ex) {
                    throw ex;
                }
            }

            //Generamos datos del archivo
            //for (var archivoKey in datosPregunta.Archivos) {
            //    var archivo = datosPregunta.Archivos[archivoKey];
            //    var nuevaRespuestaAnidada = construyeRespuestaArchivoSimple(archivo);
            //    nuevaRespuesta.RespuestasAnidadas.push(nuevaRespuestaAnidada);
            //}
            return nuevaRespuesta;
        };

        var construyeRespuestaGenerarArchivo = function (datosPregunta) {
            var nuevaRespuesta = construyeRespuestaFormulario(datosPregunta);

            return nuevaRespuesta;
        };

        //Metodos expuestos.
        return {
            generaNuevaRespuesta: generaNuevaRespuesta,
            construyeRespuesta: construyeRespuesta

        };
    });

})();