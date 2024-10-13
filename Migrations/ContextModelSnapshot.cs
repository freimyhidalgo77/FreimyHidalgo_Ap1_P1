﻿// <auto-generated />
using System;
using FreimyHidalgo_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable
             
namespace FreimyHidalgo_Ap1_P1.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        { 
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.CobroDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CobroId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CobrosCobroId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("valorCobrado")
                        .HasColumnType("REAL");

                    b.HasKey("DetalleId");

                    b.HasIndex("CobrosCobroId");

                    b.HasIndex("PrestamoId");

                    b.ToTable("CobroDetalles");
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Cobros", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeudorId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("CobroId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Deudores", b =>
                {
                    b.Property<int>("DeudorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PrestamosPrestamoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DeudorId");

                    b.HasIndex("PrestamosPrestamoId");

                    b.ToTable("Deudores");

                    b.HasData(
                        new
                        {
                            DeudorId = 1,
                            nombre = "Juan Perez"
                        },
                        new
                        {
                            DeudorId = 2,
                            nombre = "Cristal Hernandez"
                        },
                        new
                        {
                            DeudorId = 3,
                            nombre = "Maria Sanchez"
                        },
                        new
                        {
                            DeudorId = 4,
                            nombre = "Hancock Smith"
                        });
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Prestamos", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DeudorId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("balance")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("monto")
                        .HasColumnType("TEXT");

                    b.HasKey("PrestamoId");

                    b.HasIndex("DeudorId");

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.CobroDetalle", b =>
                {
                    b.HasOne("FreimyHidalgo_Ap1_P1.Models.Cobros", null)
                        .WithMany("CobroDetalles")
                        .HasForeignKey("CobrosCobroId");

                    b.HasOne("FreimyHidalgo_Ap1_P1.Models.Prestamos", "prestamos")
                        .WithMany()
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("prestamos");
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Cobros", b =>
                {
                    b.HasOne("FreimyHidalgo_Ap1_P1.Models.Deudores", "Deudores")
                        .WithMany()
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deudores");
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Deudores", b =>
                {
                    b.HasOne("FreimyHidalgo_Ap1_P1.Models.Prestamos", null)
                        .WithMany("Deudores")
                        .HasForeignKey("PrestamosPrestamoId");
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Prestamos", b =>
                {
                    b.HasOne("FreimyHidalgo_Ap1_P1.Models.Deudores", "deudor")
                        .WithMany()
                        .HasForeignKey("DeudorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("deudor");
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Cobros", b =>
                {
                    b.Navigation("CobroDetalles");
                });

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Prestamos", b =>
                {
                    b.Navigation("Deudores");
                });
#pragma warning restore 612, 618
        }
    }
}
