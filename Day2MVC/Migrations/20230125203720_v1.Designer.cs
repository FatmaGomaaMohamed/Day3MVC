﻿// <auto-generated />
using System;
using Day2MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Day2MVC.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20230125203720_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Day2MVC.Models.Department", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.HasIndex("ESSN")
                        .IsUnique()
                        .HasFilter("[ESSN] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Day2MVC.Models.Dependent", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("SSN")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name", "SSN");

                    b.HasIndex("SSN");

                    b.ToTable("Dependents");
                });

            modelBuilder.Entity("Day2MVC.Models.Employee", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SSN"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Bdate")
                        .HasColumnType("date");

                    b.Property<int?>("DeptId")
                        .HasColumnType("int");

                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("Sex")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SSN");

                    b.HasIndex("DeptId");

                    b.HasIndex("ESSN");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Day2MVC.Models.Location", b =>
                {
                    b.Property<string>("location")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("deptNumber")
                        .HasColumnType("int");

                    b.Property<int?>("LocationdeptNumber")
                        .HasColumnType("int");

                    b.Property<string>("location1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("location", "deptNumber");

                    b.HasIndex("deptNumber");

                    b.HasIndex("location1", "LocationdeptNumber");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Day2MVC.Models.Project", b =>
                {
                    b.Property<int>("PNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PNumber"));

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Loc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationdeptNumber")
                        .HasColumnType("int");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PNumber");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("location", "LocationdeptNumber");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Day2MVC.Models.Works_On", b =>
                {
                    b.Property<int?>("ESSN")
                        .HasColumnType("int");

                    b.Property<int?>("proNumber")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.HasKey("ESSN", "proNumber");

                    b.HasIndex("proNumber");

                    b.ToTable("Works_s");
                });

            modelBuilder.Entity("Day2MVC.Models.Department", b =>
                {
                    b.HasOne("Day2MVC.Models.Employee", "EmpManage")
                        .WithOne("Manage")
                        .HasForeignKey("Day2MVC.Models.Department", "ESSN");

                    b.Navigation("EmpManage");
                });

            modelBuilder.Entity("Day2MVC.Models.Dependent", b =>
                {
                    b.HasOne("Day2MVC.Models.Employee", "emp")
                        .WithMany("dependents")
                        .HasForeignKey("SSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("emp");
                });

            modelBuilder.Entity("Day2MVC.Models.Employee", b =>
                {
                    b.HasOne("Day2MVC.Models.Department", "Works_For")
                        .WithMany("EmpWork")
                        .HasForeignKey("DeptId");

                    b.HasOne("Day2MVC.Models.Employee", "Supervisor")
                        .WithMany("employees")
                        .HasForeignKey("ESSN");

                    b.Navigation("Supervisor");

                    b.Navigation("Works_For");
                });

            modelBuilder.Entity("Day2MVC.Models.Location", b =>
                {
                    b.HasOne("Day2MVC.Models.Department", "department")
                        .WithMany("locations")
                        .HasForeignKey("deptNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2MVC.Models.Location", null)
                        .WithMany("locations")
                        .HasForeignKey("location1", "LocationdeptNumber");

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2MVC.Models.Project", b =>
                {
                    b.HasOne("Day2MVC.Models.Department", "department")
                        .WithMany("projects")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Day2MVC.Models.Location", null)
                        .WithMany("Projects")
                        .HasForeignKey("location", "LocationdeptNumber");

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2MVC.Models.Works_On", b =>
                {
                    b.HasOne("Day2MVC.Models.Employee", "emp")
                        .WithMany("works_Ons")
                        .HasForeignKey("ESSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2MVC.Models.Project", "pro")
                        .WithMany("works_Ons")
                        .HasForeignKey("proNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("emp");

                    b.Navigation("pro");
                });

            modelBuilder.Entity("Day2MVC.Models.Department", b =>
                {
                    b.Navigation("EmpWork");

                    b.Navigation("locations");

                    b.Navigation("projects");
                });

            modelBuilder.Entity("Day2MVC.Models.Employee", b =>
                {
                    b.Navigation("Manage");

                    b.Navigation("dependents");

                    b.Navigation("employees");

                    b.Navigation("works_Ons");
                });

            modelBuilder.Entity("Day2MVC.Models.Location", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("locations");
                });

            modelBuilder.Entity("Day2MVC.Models.Project", b =>
                {
                    b.Navigation("works_Ons");
                });
#pragma warning restore 612, 618
        }
    }
}
