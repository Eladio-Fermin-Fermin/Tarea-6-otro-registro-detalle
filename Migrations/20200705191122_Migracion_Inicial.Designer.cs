﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarea6RegistroDetalle2.DAL;

namespace Tarea6RegistroDetalle2.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200705191122_Migracion_Inicial")]
    partial class Migracion_Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("Tarea6RegistroDetalle2.Entidades.Ordenes", b =>
                {
                    b.Property<int>("OrdenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("Monto")
                        .HasColumnType("REAL");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrdenId");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("Tarea6RegistroDetalle2.Entidades.OrdenesDetalles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdenId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrdenId");

                    b.ToTable("OrdenesDetalles");
                });

            modelBuilder.Entity("Tarea6RegistroDetalle2.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Inventario")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 100.0,
                            Descripcion = "Leche en polvo",
                            Inventario = 10
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 350.0,
                            Descripcion = "Leche en polvo 2",
                            Inventario = 10
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 100000.0,
                            Descripcion = "Leche en polvo 3",
                            Inventario = 10
                        },
                        new
                        {
                            ProductoId = 4,
                            Costo = 120000.0,
                            Descripcion = "I7-7700K",
                            Inventario = 10
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 45000000.0,
                            Descripcion = "La Prima ",
                            Inventario = 10
                        });
                });

            modelBuilder.Entity("Tarea6RegistroDetalle2.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("SuplidorId");

                    b.ToTable("Suplidores");

                    b.HasData(
                        new
                        {
                            SuplidorId = 1,
                            Nombres = "Eladio"
                        },
                        new
                        {
                            SuplidorId = 2,
                            Nombres = "Daniel"
                        },
                        new
                        {
                            SuplidorId = 3,
                            Nombres = "Jesus"
                        },
                        new
                        {
                            SuplidorId = 4,
                            Nombres = "Juan"
                        },
                        new
                        {
                            SuplidorId = 5,
                            Nombres = "Pedro"
                        });
                });

            modelBuilder.Entity("Tarea6RegistroDetalle2.Entidades.OrdenesDetalles", b =>
                {
                    b.HasOne("Tarea6RegistroDetalle2.Entidades.Ordenes", null)
                        .WithMany("OrdenesDetalles")
                        .HasForeignKey("OrdenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}