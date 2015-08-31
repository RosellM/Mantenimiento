using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.Entity.Validation;
using System.Data.Entity;
namespace Datos
{
  public class TestDat
    {

      public List<test> listarTest()
      {
            using(bdscecEntities bd = new bdscecEntities())
            {
                return bd.test.ToList();
            }
      }

      public void nuevoTest(test test)
      {
          using (bdscecEntities bd = new bdscecEntities())
          {

              try
              {
                  bd.test.Add(test);
                  bd.SaveChanges();
              }
              catch (DbEntityValidationException e)
              {
                  throw e;
              }

          }
      }

      public void modificarTest(test test)
      {
          test getTest;
          using (var ctx = new bdscecEntities())
          {
              try
              {
                  getTest = ctx.test.Where(s => s.id == test.id).FirstOrDefault<test>();
              }
              catch (DbEntityValidationException e)
              {
                  throw e;
              }

          }

          if (getTest != null)
          {
              getTest.nombre = test.nombre;
             
          }


          using (var dbCtx = new bdscecEntities())
          {

              dbCtx.Entry(getTest).State = EntityState.Modified;

              dbCtx.SaveChanges();
          }
      }

      public test obtenerTestPorId(int id)
      {
          using (bdscecEntities bd = new bdscecEntities())
          {
              test test = (from e in bd.test where e.id == id select e).First();
              return test;
          }
      }

      public void eliminarTest(int id)
      {
          using (bdscecEntities bd = new bdscecEntities())
          {
              try
              {
                  var testAEliminar = (from e in bd.test where e.id == id select e).First();
                  bd.test.Remove(testAEliminar);
                  bd.SaveChanges();
              }
              catch (DbEntityValidationException e)
              {
                  throw e;
              }
          }
      }


    }
}
