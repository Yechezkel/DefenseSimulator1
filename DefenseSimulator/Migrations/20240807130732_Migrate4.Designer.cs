﻿// <auto-generated />
using System;
using DefenseSimulator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DefenseSimulator.Migrations
{
    [DbContext(typeof(DefenseSimulatorContext))]
    [Migration("20240807130732_Migrate4")]
    partial class Migrate4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DefenseSimulator.Models.Arsenal", b =>
                {
                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("Counter");

                    b.ToTable("Arsenal");
                });

            modelBuilder.Entity("DefenseSimulator.Models.Response", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResponseId"));

                    b.Property<DateTime?>("InterceptTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LaunchTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ResponseType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("ThreatId")
                        .HasColumnType("int");

                    b.HasKey("ResponseId");

                    b.HasIndex("ThreatId");

                    b.ToTable("Response");
                });

            modelBuilder.Entity("DefenseSimulator.Models.Threat", b =>
                {
                    b.Property<int>("ThreatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThreatId"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LaunchTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("ThreatId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Threat");
                });

            modelBuilder.Entity("DefenseSystem.Data.Models.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeaponId"));

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<int>("Radius")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapon");
                });

            modelBuilder.Entity("DefenseSimulator.Models.Response", b =>
                {
                    b.HasOne("DefenseSimulator.Models.Threat", "Threat")
                        .WithMany()
                        .HasForeignKey("ThreatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Threat");
                });

            modelBuilder.Entity("DefenseSimulator.Models.Threat", b =>
                {
                    b.HasOne("DefenseSystem.Data.Models.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Weapon");
                });
#pragma warning restore 612, 618
        }
    }
}
