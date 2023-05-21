﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ngopi.Helpers;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ngopi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230520154825_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ngopi.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Ngopi.Models.DetailProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Berat")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Dimensi")
                        .HasColumnType("text");

                    b.Property<string[]>("Images")
                        .HasColumnType("text[]");

                    b.Property<string>("Kapasitas")
                        .HasColumnType("text");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Warna")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("DetailProducts");
                });

            modelBuilder.Entity("Ngopi.Models.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Origins");
                });

            modelBuilder.Entity("Ngopi.Models.Processing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Processings");
                });

            modelBuilder.Entity("Ngopi.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("BrandId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OriginId")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int?>("ProcessingId")
                        .HasColumnType("integer");

                    b.Property<int>("RateStar")
                        .HasColumnType("integer");

                    b.Property<int?>("RoastLevelId")
                        .HasColumnType("integer");

                    b.Property<int?>("SpeciesId")
                        .HasColumnType("integer");

                    b.Property<int?>("TastedId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalRate")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("OriginId");

                    b.HasIndex("ProcessingId");

                    b.HasIndex("RoastLevelId");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("TastedId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ngopi.Models.RoastLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoastLevels");
                });

            modelBuilder.Entity("Ngopi.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specieses");
                });

            modelBuilder.Entity("Ngopi.Models.Tasted", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tasteds");
                });

            modelBuilder.Entity("Ngopi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ngopi.Models.DetailProduct", b =>
                {
                    b.HasOne("Ngopi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ngopi.Models.Product", b =>
                {
                    b.HasOne("Ngopi.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.HasOne("Ngopi.Models.Origin", "Origin")
                        .WithMany("Products")
                        .HasForeignKey("OriginId");

                    b.HasOne("Ngopi.Models.Processing", "Processing")
                        .WithMany("Products")
                        .HasForeignKey("ProcessingId");

                    b.HasOne("Ngopi.Models.RoastLevel", "RoastLevel")
                        .WithMany("Products")
                        .HasForeignKey("RoastLevelId");

                    b.HasOne("Ngopi.Models.Species", "Species")
                        .WithMany("Products")
                        .HasForeignKey("SpeciesId");

                    b.HasOne("Ngopi.Models.Tasted", "Tasted")
                        .WithMany("Products")
                        .HasForeignKey("TastedId");

                    b.Navigation("Brand");

                    b.Navigation("Origin");

                    b.Navigation("Processing");

                    b.Navigation("RoastLevel");

                    b.Navigation("Species");

                    b.Navigation("Tasted");
                });

            modelBuilder.Entity("Ngopi.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ngopi.Models.Origin", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ngopi.Models.Processing", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ngopi.Models.RoastLevel", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ngopi.Models.Species", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ngopi.Models.Tasted", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
