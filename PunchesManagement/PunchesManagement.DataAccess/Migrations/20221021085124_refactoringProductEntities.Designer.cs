﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PunchesManagement.DataAccess;

#nullable disable

namespace PunchesManagement.DataAccess.Migrations
{
    [DbContext(typeof(PunchesManagementContext))]
    [Migration("20221021085124_refactoringProductEntities")]
    partial class refactoringProductEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BatchSize")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Output")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProductionTimeStop")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PunchesId")
                        .HasColumnType("int");

                    b.Property<decimal>("RealWorkingTime")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TabletPressId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PunchesId");

                    b.HasIndex("TabletPressId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Punches", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("InInspection")
                        .HasColumnType("bit");

                    b.Property<decimal>("MachineHour")
                        .HasPrecision(6, 2)
                        .HasColumnType("decimal(6,2)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TypesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("TypesId");

                    b.ToTable("Punches");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.TabletPress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberOfStation")
                        .HasColumnType("int");

                    b.Property<string>("Producer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TypesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypesId");

                    b.ToTable("TabletPresses");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Types", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("PunchesTabletPress", b =>
                {
                    b.Property<int>("PunchesId")
                        .HasColumnType("int");

                    b.Property<int>("TabletPressId")
                        .HasColumnType("int");

                    b.HasKey("PunchesId", "TabletPressId");

                    b.HasIndex("TabletPressId");

                    b.ToTable("PunchesTabletPress");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("PunchesManagement.DataAccess.Entities.Punches", null)
                        .WithMany("Products")
                        .HasForeignKey("PunchesId");

                    b.HasOne("PunchesManagement.DataAccess.Entities.TabletPress", "TabletPress")
                        .WithMany("Products")
                        .HasForeignKey("TabletPressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TabletPress");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Punches", b =>
                {
                    b.HasOne("PunchesManagement.DataAccess.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Punches")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PunchesManagement.DataAccess.Entities.Types", "Types")
                        .WithMany("Punches")
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Manufacturer");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.TabletPress", b =>
                {
                    b.HasOne("PunchesManagement.DataAccess.Entities.Types", "Types")
                        .WithMany("TabletPress")
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Types");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.User", b =>
                {
                    b.HasOne("PunchesManagement.DataAccess.Entities.UserRole", "UserRole")
                        .WithMany("User")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("PunchesTabletPress", b =>
                {
                    b.HasOne("PunchesManagement.DataAccess.Entities.Punches", null)
                        .WithMany()
                        .HasForeignKey("PunchesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PunchesManagement.DataAccess.Entities.TabletPress", null)
                        .WithMany()
                        .HasForeignKey("TabletPressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Manufacturer", b =>
                {
                    b.Navigation("Punches");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Punches", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.TabletPress", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Types", b =>
                {
                    b.Navigation("Punches");

                    b.Navigation("TabletPress");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.UserRole", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
