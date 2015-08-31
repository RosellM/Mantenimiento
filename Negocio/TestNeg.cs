using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
   public class TestNeg
    {

       public List<test> listarTest() 
       {
           return new TestDat().listarTest();
       }

       public void nuevoTest(test test)
       {
           new TestDat().nuevoTest(test);
       }

       public test obtenerTestPorID(int id)
       {
           return new TestDat().obtenerTestPorId(id);
       }

       public void eliminarTest(int id) 
       {
           new TestDat().eliminarTest(id);
       }

       public void modificarTest(test test) 
       {
           new TestDat().modificarTest(test);
       }

    }
}
