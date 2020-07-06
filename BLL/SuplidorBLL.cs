using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea6RegistroDetalle2.DAL;
using Tarea6RegistroDetalle2.Entidades;

namespace Tarea6RegistroDetalle2.BLL
{
    public class SuplidorBLL
    {
        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                paso = contexto.Suplidores.Any(s => s.SuplidorId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        //Metodo Modificar.
        private static bool Modificar(Suplidores suplidor)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(suplidor).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        //Metodo Insertar.
        private static bool Insertar(Suplidores suplidores)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Suplidores.Add(suplidores);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        //Metodo Guardar.
        public static bool Guardar(Suplidores suplidores)
        {
            if (!Existe(suplidores.SuplidorId))
                return Insertar(suplidores);
            else
                return Modificar(suplidores);
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var orden = contexto.Suplidores.Find(id);
                contexto.Suplidores.Remove(orden);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.SaveChanges();
            }

            return paso;
        }

        //Metodo Buscar.
        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidores;

            try
            {
                suplidores = contexto.Suplidores.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidores;
        }
        public static List<Suplidores> GetSuplidores()
        {
            Contexto contexto = new Contexto();
            List<Suplidores> suplidores = new List<Suplidores>();

            try
            {
                suplidores = contexto.Suplidores.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return suplidores;
        }

    }
}
