using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
    public class PreguntaNeg
    {
        public List<pregunta> listarPregunta()
        {
            return new PreguntaDat().listarpregunta();
        }

        public void nuevoPregunta(pregunta Pregunta)
        {
            new PreguntaDat().nuevopregunta(Pregunta);
        }

        public pregunta obtenerPreguntaPorID(int id)
        {
            return new PreguntaDat().obtenerpreguntaPorId(id);
        }

        public void eliminarPregunta(int id)
        {
            new PreguntaDat().eliminarpregunta(id);
        }

        public void modificarPregunta(pregunta Pregunta)
        {
            new PreguntaDat().modificarpregunta(Pregunta);
        }

    }
}
