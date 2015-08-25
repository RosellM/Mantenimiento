using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocio
{
  public class ciudadesNeg
    {

      public void guardarCiudad(ciudad ciudad)
      {
          new ciudadesDat().guardarCiudad(ciudad);
      }

      public List<ciudad> listarCiudades() 
      {
          return new ciudadesDat().listarCiudades();
      }

      public estados nombreEstado(int idEstado)
      {
          return new ciudadesDat().obtenerNombreEstado(idEstado);
      }

      public List<estados> estados() 
      {
          return new estadoNeg().listarEstados();
      }


      public ciudad obtenerCiudadPorID(int id)
      {
          return new ciudadesDat().obtenerCiudadPorId(id);
      }

      public void modificarCiudad(ciudad ciudad) 
      {
          new ciudadesDat().modificarCiudad(ciudad);
      }

      public int eliminarCiudads(int id)
      {
         return new ciudadesDat().eliminarEstado(id);
      }

    }
}
