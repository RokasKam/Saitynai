﻿// <auto-generated />
using System;
using HikingInformationSystemInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HikingInformationSystemInfrastructure.Migrations
{
    [DbContext(typeof(HikingInformationSystemDataContext))]
    [Migration("20241013174052_ChangeTimeType")]
    partial class ChangeTimeType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HikingInformationSystemDomain.Entities.Hike", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Accessibility")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seasonality")
                        .HasColumnType("int");

                    b.Property<bool>("SuitableForBeginners")
                        .HasColumnType("bit");

                    b.Property<int>("TerrainType")
                        .HasColumnType("int");

                    b.Property<double>("TotalDistance")
                        .HasColumnType("float");

                    b.Property<double>("TotalDurationInMinutes")
                        .HasColumnType("float");

                    b.Property<double>("TotalElevationGain")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Hikes");
                });

            modelBuilder.Entity("HikingInformationSystemDomain.Entities.Point", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Altitude")
                        .HasColumnType("float");

                    b.Property<int>("Feature")
                        .HasColumnType("int");

                    b.Property<string>("FeatureDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("OrderInRoute")
                        .HasColumnType("int");

                    b.Property<int>("PointType")
                        .HasColumnType("int");

                    b.Property<Guid>("RouteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("HikingInformationSystemDomain.Entities.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<double>("DurationInMinutes")
                        .HasColumnType("float");

                    b.Property<double>("ElevationChange")
                        .HasColumnType("float");

                    b.Property<Guid>("HikeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NavigationNotes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderInHike")
                        .HasColumnType("int");

                    b.Property<int>("SurfaceType")
                        .HasColumnType("int");

                    b.Property<int>("TerrainType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HikeId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("HikingInformationSystemDomain.Entities.Point", b =>
                {
                    b.HasOne("HikingInformationSystemDomain.Entities.Route", "Route")
                        .WithMany("Points")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("HikingInformationSystemDomain.Entities.Route", b =>
                {
                    b.HasOne("HikingInformationSystemDomain.Entities.Hike", "Hike")
                        .WithMany("Routes")
                        .HasForeignKey("HikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hike");
                });

            modelBuilder.Entity("HikingInformationSystemDomain.Entities.Hike", b =>
                {
                    b.Navigation("Routes");
                });

            modelBuilder.Entity("HikingInformationSystemDomain.Entities.Route", b =>
                {
                    b.Navigation("Points");
                });
#pragma warning restore 612, 618
        }
    }
}
