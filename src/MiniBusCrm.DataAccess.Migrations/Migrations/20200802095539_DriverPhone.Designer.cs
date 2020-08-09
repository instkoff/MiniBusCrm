﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniBusCrm.DataAccess.Implementations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MiniBusCrm.DataAccess.Migrations.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200802095539_DriverPhone")]
    partial class DriverPhone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.BusDriverEntity", b =>
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

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BusDrivers");
                });

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

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.PassengerEntity", b =>
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

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.PlaneEntity", b =>
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

                    b.Property<string>("PlaneName")
                        .HasColumnType("text");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.RouteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ArrivalCity")
                        .HasColumnType("text");

                    b.Property<Guid?>("BusDriverId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BusId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DepartureCity")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("RouteName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusDriverId");

                    b.HasIndex("BusId");

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

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("PassengerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PlaneId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Seat")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("PlaneId");

                    b.HasIndex("RouteId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.PlaneEntity", b =>
                {
                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.RouteEntity", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.RouteEntity", b =>
                {
                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.BusDriverEntity", "BusDriver")
                        .WithMany()
                        .HasForeignKey("BusDriverId");

                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.BusEntity", "Bus")
                        .WithMany()
                        .HasForeignKey("BusId");
                });

            modelBuilder.Entity("MiniBusCrm.DataAccess.Contracts.Entities.TicketEntity", b =>
                {
                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.PassengerEntity", "Passenger")
                        .WithMany("BusTickets")
                        .HasForeignKey("PassengerId");

                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.PlaneEntity", "Plane")
                        .WithMany("BusTickets")
                        .HasForeignKey("PlaneId");

                    b.HasOne("MiniBusCrm.DataAccess.Contracts.Entities.RouteEntity", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");
                });
#pragma warning restore 612, 618
        }
    }
}