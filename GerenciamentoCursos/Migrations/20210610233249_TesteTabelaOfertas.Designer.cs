﻿// <auto-generated />
using System;
using GerenciamentoCursos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciamentoCursos.Migrations
{
    [DbContext(typeof(GerenciamentoCursosContext))]
    [Migration("20210610233249_TesteTabelaOfertas")]
    partial class TesteTabelaOfertas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GerenciamentoCursos.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("TipoCurso");

                    b.Property<int?>("TipoId");

                    b.HasKey("Id");

                    b.HasIndex("TipoId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("GerenciamentoCursos.Models.Localidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cidade");

                    b.Property<string>("Estado");

                    b.HasKey("Id");

                    b.ToTable("Localidade");
                });

            modelBuilder.Entity("GerenciamentoCursos.Models.Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cidade");

                    b.Property<int?>("CursoId");

                    b.Property<string>("Estado");

                    b.Property<string>("NomeCurso");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("GerenciamentoCursos.Models.Tipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TipoCurso")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("GerenciamentoCursos.Models.Curso", b =>
                {
                    b.HasOne("GerenciamentoCursos.Models.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId");
                });

            modelBuilder.Entity("GerenciamentoCursos.Models.Oferta", b =>
                {
                    b.HasOne("GerenciamentoCursos.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");
                });
#pragma warning restore 612, 618
        }
    }
}
