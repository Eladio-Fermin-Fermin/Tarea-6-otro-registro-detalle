using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tarea6RegistroDetalle2.Entidades;

namespace Tarea6RegistroDetalle2.DAL
{
   public class Contexto :DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Orden.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Registro de los suplidores
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 1, Nombres = "Eladio" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 2, Nombres = "Daniel" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 3, Nombres = "Jesus" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 4, Nombres = "Juan" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 5, Nombres = "Pedro" });

            //Registro de los Productos
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 1,
                Costo = 100,
                Descripcion = "Leche en polvo",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 2,
                Costo = 350,
                Descripcion = "Leche en polvo 2",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 3,
                Costo = 100000,
                Descripcion = "Leche en polvo 3",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 4,
                Costo = 120000,
                Descripcion = "I7-7700K",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 5,
                Costo = 45000000,
                Descripcion = "La Prima ",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 6,
                Costo = 45000000,
                Descripcion = "La Prima 2",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 7,
                Costo = 45000000,
                Descripcion = "La Prima 3",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 8,
                Costo = 45000000,
                Descripcion = "La Prima 4",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 9,
                Costo = 45000000,
                Descripcion = "La Prima 5",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 10,
                Costo = 45000000,
                Descripcion = "La Prima 6",
                Inventario = 10
            });

        }
    }
}
