﻿// <auto-generated />
using System;
using Escalada.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Escalada.Migrations
{
    [DbContext(typeof(EscaladaContext))]
    [Migration("20200612162904_Provider")]
    partial class Provider
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Escalada.Models.Agreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProviderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("Escalada.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("NumFone1")
                        .HasColumnType("text");

                    b.Property<string>("NumFone2")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Escalada.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Capacidade")
                        .HasColumnType("integer");

                    b.Property<string>("Cronograma")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataTermino")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean");

                    b.Property<string>("Local")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<decimal>("OrcamentoPrevio")
                        .HasColumnType("numeric");

                    b.Property<int>("Quorum")
                        .HasColumnType("integer");

                    b.Property<int?>("StatusId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorIngresso")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Escalada.Models.EventStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EventStatus");
                });

            modelBuilder.Entity("Escalada.Models.Inscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<int?>("EventoId")
                        .HasColumnType("integer");

                    b.Property<int>("QtdInteira")
                        .HasColumnType("integer");

                    b.Property<int>("QtdMeia")
                        .HasColumnType("integer");

                    b.Property<int?>("TipoPagamentoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorRecebido")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EventoId");

                    b.HasIndex("TipoPagamentoId");

                    b.ToTable("Inscriptions");
                });

            modelBuilder.Entity("Escalada.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Escalada.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Responsavel")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Escalada.Models.Agreement", b =>
                {
                    b.HasOne("Escalada.Models.Event", "Event")
                        .WithMany("Fornecedores")
                        .HasForeignKey("EventId");

                    b.HasOne("Escalada.Models.Provider", "Provider")
                        .WithMany("AgreementId")
                        .HasForeignKey("ProviderId");
                });

            modelBuilder.Entity("Escalada.Models.Event", b =>
                {
                    b.HasOne("Escalada.Models.EventStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("Escalada.Models.Inscription", b =>
                {
                    b.HasOne("Escalada.Models.Customer", "Cliente")
                        .WithMany("Inscricoes")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Escalada.Models.Event", "Evento")
                        .WithMany("Inscricoes")
                        .HasForeignKey("EventoId");

                    b.HasOne("Escalada.Models.PaymentType", "TipoPagamento")
                        .WithMany()
                        .HasForeignKey("TipoPagamentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
