﻿// <auto-generated />
using ChainTransmissionAPI.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChainTransmissionAPI.Migrations.StaticVariables
{
    [DbContext(typeof(StaticVariablesContext))]
    partial class StaticVariablesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChainTransmissionAPI.Models.AssemblyUnitProp", b =>
                {
                    b.Property<double>("Tc")
                        .HasColumnType("double precision")
                        .HasColumnName("tc");

                    b.Property<string>("SM")
                        .HasColumnType("text");

                    b.Property<double>("V")
                        .HasColumnType("double precision")
                        .HasColumnName("v");

                    b.HasKey("Tc", "SM");

                    b.ToTable("AssemblyUnitProps");
                });

            modelBuilder.Entity("ChainTransmissionAPI.Models.Chain", b =>
                {
                    b.Property<string>("ND")
                        .HasColumnType("text");

                    b.Property<double>("S")
                        .HasColumnType("double precision");

                    b.Property<double>("Tc")
                        .HasColumnType("double precision")
                        .HasColumnName("tc");

                    b.HasKey("ND");

                    b.ToTable("Chains");
                });

            modelBuilder.Entity("ChainTransmissionAPI.Models.Gear", b =>
                {
                    b.Property<int>("Z")
                        .HasColumnType("integer")
                        .HasColumnName("z");

                    b.Property<double>("Tc")
                        .HasColumnType("double precision")
                        .HasColumnName("tc");

                    b.Property<double>("N")
                        .HasColumnType("double precision");

                    b.HasKey("Z", "Tc");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("ChainTransmissionAPI.Models.UnitProp", b =>
                {
                    b.Property<string>("TN")
                        .HasColumnType("text");

                    b.Property<string>("TU")
                        .HasColumnType("text");

                    b.Property<double>("K_d")
                        .HasColumnType("double precision");

                    b.HasKey("TN", "TU");

                    b.ToTable("UnitProps");
                });
#pragma warning restore 612, 618
        }
    }
}