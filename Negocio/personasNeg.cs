using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
 public class personasNeg
    {

        public List<personas> listarPersonas()
        {
           return new personasDat().listarPersonas();
        }

        public void NuevaPersona( personas persona)
        {
            new personasDat().nuevaPersona(persona);
        }

        public personas obternerPersonasPorID(int id)
        {
            return new personasDat().obtenerPersonaPorID(id);
        }


        public void modificarPersonas(personas personas)
        {

            new personasDat().modificarPersona(personas);

        }

        public void eliminarPersonas(int id) 
        {
            new personasDat().eliminarPersonas(id);
        }
    }
}
