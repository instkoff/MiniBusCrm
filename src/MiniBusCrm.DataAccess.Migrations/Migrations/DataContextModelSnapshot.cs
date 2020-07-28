﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniBusCrm.DataAccess.Implementations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MiniBusCrm.DataAccess.Migrations.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.BusEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.DriverEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("text");

                    b.Property<string>("DoumentSerialNumber")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("OrderName")
                        .HasColumnType("text");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.PassangerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Passangers");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.RouteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ArrivalCity")
                        .HasColumnType("text");

                    b.Property<Guid?>("BusId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DepartureCity")
                        .HasColumnType("text");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("RouteName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("DriverId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.TicketEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBaggage")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("PassengerId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Seat")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PassengerId");

                    b.HasIndex("RouteId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.OrderEntity", b =>
                {
                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.RouteEntity", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.RouteEntity", b =>
                {
                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.BusEntity", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");

                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.DriverEntity", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.TicketEntity", b =>
                {
                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.OrderEntity", "Order")
                        .WithMany("BusTickets")
                        .HasForeignKey("OrderId");

                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.PassangerEntity", "Passenger")
                        .WithMany("BusTickets")
                        .HasForeignKey("PassengerId");

                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.RouteEntity", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");
                });
#pragma warning restore 612, 618
        }
    }
}
