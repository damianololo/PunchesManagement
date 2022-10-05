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
    [Migration("20221004195948_FirstEntities")]
    partial class FirstEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Output")
                        .HasColumnType("int");

                    b.Property<DateTime>("ProductionTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.Property<int>("TabletPressId")
                        .HasColumnType("int");

                    b.Property<int>("WorkingTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

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

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TabletPressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UsingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TabletPressId");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfStation")
                        .HasColumnType("int");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TabletPresses");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("PunchesManagement.DataAccess.Entities.TabletPress", "TabletPress")
                        .WithMany("Products")
                        .HasForeignKey("TabletPressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TabletPress");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.Punches", b =>
                {
                    b.HasOne("PunchesManagement.DataAccess.Entities.TabletPress", "TabletPress")
                        .WithMany("Punches")
                        .HasForeignKey("TabletPressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TabletPress");
                });

            modelBuilder.Entity("PunchesManagement.DataAccess.Entities.TabletPress", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Punches");
                });
#pragma warning restore 612, 618
        }
    }
}
