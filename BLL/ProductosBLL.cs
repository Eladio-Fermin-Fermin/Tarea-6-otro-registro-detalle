using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea6RegistroDetalle2.DAL;
using Tarea6RegistroDetalle2.Entidades;

namespace Tarea6RegistroDetalle2.BLL
{
    public class ProductosBLL
    {
        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                paso = contexto.Productos.Any(s => s.ProductoId == id);
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
        private static bool Insertar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Productos.Add(producto);
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
        private static bool Modificar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
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
        public static bool Guardar(Productos producto)
        {
            if (!Existe(producto.ProductoId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        //Metodo Buscar.
        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos productos;

            try
            {
                productos = contexto.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return productos;
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var producto = contexto.Productos.Find(id);
                contexto.Productos.Remove(producto);
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

        //Metodo List.
        public static List<Productos> GetProductos()
        {
            Contexto contexto = new Contexto();
            List<Productos> productos = new List<Productos>();

            try
            {
                productos = contexto.Productos.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return productos;
        }
    }
}
