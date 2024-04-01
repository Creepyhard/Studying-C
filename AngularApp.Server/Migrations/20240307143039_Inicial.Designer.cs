﻿// <auto-generated />
using System;
using AngularApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngularApp.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240307143039_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AngularApp.Server.Model.HistoricoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Chute")
                        .HasColumnType("int");

                    b.Property<string>("CodigoUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("COD_JOGADOR");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_HR_TENTATIVA");

                    b.Property<int>("Resultado")
                        .HasColumnType("int")
                        .HasColumnName("RESULTADO");

                    b.Property<int>("Tentativa")
                        .HasColumnType("int")
                        .HasColumnName("TENTATIVA");

                    b.HasKey("Id");

                    b.ToTable("Historicos");
                });
#pragma warning restore 612, 618
        }
    }
}
