using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea6RegistroDetalle2.DAL;
using Tarea6RegistroDetalle2.Entidades;

namespace Tarea6RegistroDetalle2.BLL
{
    public class OrdenesBLL
    {
        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                paso = contexto.Ordenes.Any(o => o.OrdenId == id);
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
        private static bool Insertar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Ordenes.Add(ordenes);
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

        //Metodo Modificar.
        public static bool Modificar(Ordenes ordenes)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where OrdenId={ordenes.OrdenId}");

                foreach (var anterior in ordenes.OrdenesDetalles)

                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(ordenes).State = EntityState.Modified;
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
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenId))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }

        //Metodo Buscar.
        public static Ordenes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordenes ordenes;

            try
            {
                ordenes = contexto.Ordenes.Include(o => o.OrdenesDetalles).Where(p => p.OrdenId == id).SingleOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ordenes;
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var orden = contexto.Ordenes.Find(id);
                contexto.Entry(orden).State = EntityState.Deleted;
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

    }
}
