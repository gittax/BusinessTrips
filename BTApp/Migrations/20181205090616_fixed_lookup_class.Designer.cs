﻿// <auto-generated />
using System;
using BTApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BTApp.Migrations
{
    [DbContext(typeof(BusinessTripContext))]
    [Migration("20181205090616_fixed_lookup_class")]
    partial class fixed_lookup_class
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BTApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("BirthPlace");

                    b.Property<string>("DocNumber");

                    b.Property<int>("DocType");

                    b.Property<int>("EmployeeBaseId");

                    b.Property<int>("Gender");

                    b.Property<int?>("RequestId");

                    b.Property<DateTime>("ValidThrough");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeBaseId")
                        .IsUnique();

                    b.HasIndex("RequestId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BTApp.Models.EmployeeBase", b =>
                {
                    b.Property<int>("EmployeeBaseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("EmployeeBaseId");

                    b.ToTable("EmployeeBase");
                });

            modelBuilder.Entity("BTApp.Models.EmployeeBaseProjectAssign", b =>
                {
                    b.Property<int>("EmployeeBaseId");

                    b.Property<int>("ProjectId");

                    b.Property<int?>("EmployeeId");

                    b.HasKey("EmployeeBaseId", "ProjectId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeBaseProjectAssign");
                });

            modelBuilder.Entity("BTApp.Models.EmployeeRouteAssign", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("RouteId");

                    b.HasKey("EmployeeId", "RouteId");

                    b.HasIndex("RouteId");

                    b.ToTable("EmployeeRouteAssign");
                });

            modelBuilder.Entity("BTApp.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ManagerId");

                    b.Property<string>("Name");

                    b.HasKey("ProjectId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("BTApp.Models.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Budget");

                    b.Property<string>("BusinessTripNumber");

                    b.Property<double>("Cost");

                    b.Property<DateTime>("Date");

                    b.Property<int>("DeclarerId");

                    b.Property<int>("ManagerId");

                    b.Property<int>("OfficeManagerId");

                    b.Property<int?>("ProjectId");

                    b.Property<string>("RequestNumber");

                    b.Property<int>("Status");

                    b.Property<int?>("SubprojectId");

                    b.HasKey("RequestId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SubprojectId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("BTApp.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArrivalCity");

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<double>("Budget");

                    b.Property<int>("ClassType");

                    b.Property<string>("DepartureCity");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<string>("FlightNumber");

                    b.Property<int?>("RequestId");

                    b.Property<int>("RouteType");

                    b.Property<int>("TicketType");

                    b.HasKey("RouteId");

                    b.HasIndex("RequestId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("BTApp.Models.Subproject", b =>
                {
                    b.Property<int>("SubprojectId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("ProjectId");

                    b.HasKey("SubprojectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Subproject");
                });

            modelBuilder.Entity("BTApp.Models.Ticket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<double>("Cost");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("RequestId");

                    b.Property<int>("RouteType");

                    b.HasKey("TicketId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("RequestId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("BTApp.Models.Employee", b =>
                {
                    b.HasOne("BTApp.Models.EmployeeBase", "EmployeeBase")
                        .WithOne("Employee")
                        .HasForeignKey("BTApp.Models.Employee", "EmployeeBaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BTApp.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("BTApp.Models.EmployeeBaseProjectAssign", b =>
                {
                    b.HasOne("BTApp.Models.EmployeeBase", "EmployeeBase")
                        .WithMany("EmployeeProjectAssigns")
                        .HasForeignKey("EmployeeBaseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BTApp.Models.Employee")
                        .WithMany("EmployeeProjectAssigns")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("BTApp.Models.Project", "Project")
                        .WithMany("EmployeeProjectAssigns")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BTApp.Models.EmployeeRouteAssign", b =>
                {
                    b.HasOne("BTApp.Models.Employee", "Employee")
                        .WithMany("EmployeeRouteAssigns")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BTApp.Models.Route", "Route")
                        .WithMany("EmployeeRouteAssigns")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BTApp.Models.Project", b =>
                {
                    b.HasOne("BTApp.Models.EmployeeBase", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("BTApp.Models.Request", b =>
                {
                    b.HasOne("BTApp.Models.Project")
                        .WithMany("Requests")
                        .HasForeignKey("ProjectId");

                    b.HasOne("BTApp.Models.Subproject")
                        .WithMany("Requests")
                        .HasForeignKey("SubprojectId");
                });

            modelBuilder.Entity("BTApp.Models.Route", b =>
                {
                    b.HasOne("BTApp.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("BTApp.Models.Subproject", b =>
                {
                    b.HasOne("BTApp.Models.Project", "Project")
                        .WithMany("Subprojects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BTApp.Models.Ticket", b =>
                {
                    b.HasOne("BTApp.Models.Employee", "Employee")
                        .WithOne("Ticket")
                        .HasForeignKey("BTApp.Models.Ticket", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BTApp.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");
                });
#pragma warning restore 612, 618
        }
    }
}
