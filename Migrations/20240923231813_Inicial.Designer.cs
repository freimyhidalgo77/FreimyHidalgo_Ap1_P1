﻿// <auto-generated />
using FreimyHidalgo_Ap1_P1.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FreimyHidalgo_Ap1_P1.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240923231813_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("FreimyHidalgo_Ap1_P1.Models.Registro", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("id")
                        .HasColumnType("INTEGER");

                    b.HasKey("name");

                    b.ToTable("Regitro");
                });
#pragma warning restore 612, 618
        }
    }
}
