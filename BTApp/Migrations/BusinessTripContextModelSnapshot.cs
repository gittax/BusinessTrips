﻿// <auto-generated />
using System;
using BTApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BTApp.Migrations
{
    [DbContext(typeof(BusinessTripContext))]
    partial class BusinessTripContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("EmployeeBaseId");

                    b.Property<int>("Gender");

                    b.Property<int?>("RequestId");

                    b.Property<DateTime>("ValidThrough");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeBaseId");

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

            modelBuilder.Entity("BTApp.Models.EmployeeProjectAssign", b =>
                {
                    b.Property<int>("EmployeeID");

                    b.Property<int>("ProjectID");

                    b.Property<int?>("EmployeeBaseId");

                    b.HasKey("EmployeeID", "ProjectID");

                    b.HasIndex("EmployeeBaseId");

                    b.HasIndex("ProjectID");

                    b.ToTable("EmployeeProjectAssign");
                });

            modelBuilder.Entity("BTApp.Models.EmployeeRouteAssign", b =>
                {
                    b.Property<int>("EmployeeID");

                    b.Property<int>("RouteID");

                    b.HasKey("EmployeeID", "RouteID");

                    b.HasIndex("RouteID");

                    b.ToTable("EmployeeRouteAssign");
                });

            modelBuilder.Entity("BTApp.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ManagerEmployeeBaseId");

                    b.Property<string>("Name");

                    b.HasKey("ProjectID");

                    b.HasIndex("ManagerEmployeeBaseId");

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

                    b.Property<string>("Declarer");

                    b.Property<int?>("ManagerEmployeeBaseId");

                    b.Property<int?>("OfficeManagerEmployeeBaseId");

                    b.Property<int?>("ProjectID");

                    b.Property<string>("RequestNumber");

                    b.Property<int>("Status");

                    b.HasKey("RequestId");

                    b.HasIndex("ManagerEmployeeBaseId");

                    b.HasIndex("OfficeManagerEmployeeBaseId");

                    b.HasIndex("ProjectID");

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectID");

                    b.HasKey("Id");

                    b.HasIndex("ProjectID");

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

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("RequestId");

                    b.Property<int>("RouteType");

                    b.HasKey("TicketId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RequestId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("BTApp.Models.Employee", b =>
                {
                    b.HasOne("BTApp.Models.EmployeeBase", "EmployeeBase")
                        .WithMany()
                        .HasForeignKey("EmployeeBaseId");

                    b.HasOne("BTApp.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");
                });

            modelBuilder.Entity("BTApp.Models.EmployeeProjectAssign", b =>
                {
                    b.HasOne("BTApp.Models.EmployeeBase", "EmployeeBase")
                        .WithMany("EmployeeProjectAssigns")
                        .HasForeignKey("EmployeeBaseId");

                    b.HasOne("BTApp.Models.Project", "Project")
                        .WithMany("EmployeeProjectAssigns")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BTApp.Models.EmployeeRouteAssign", b =>
                {
                    b.HasOne("BTApp.Models.Employee", "Employee")
                        .WithMany("EmployeeRouteAssigns")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BTApp.Models.Route", "Route")
                        .WithMany("EmployeeRouteAssigns")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BTApp.Models.Project", b =>
                {
                    b.HasOne("BTApp.Models.EmployeeBase", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerEmployeeBaseId");
                });

            modelBuilder.Entity("BTApp.Models.Request", b =>
                {
                    b.HasOne("BTApp.Models.EmployeeBase", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerEmployeeBaseId");

                    b.HasOne("BTApp.Models.EmployeeBase", "OfficeManager")
                        .WithMany()
                        .HasForeignKey("OfficeManagerEmployeeBaseId");

                    b.HasOne("BTApp.Models.Project", "Project")
                        .WithMany("Requests")
                        .HasForeignKey("ProjectID");
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
                        .HasForeignKey("ProjectID");
                });

            modelBuilder.Entity("BTApp.Models.Ticket", b =>
                {
                    b.HasOne("BTApp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("BTApp.Models.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");
                });
#pragma warning restore 612, 618
        }
    }
}
