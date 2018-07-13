﻿// <auto-generated />
using eShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace eShop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eShop.Data.Entities.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("eShop.Data.Entities.Os", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Oses");
                });

            modelBuilder.Entity("eShop.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Camera");

                    b.Property<string>("Description");

                    b.Property<string>("ImageLarge")
                        .HasMaxLength(50);

                    b.Property<string>("ImageSmall")
                        .HasMaxLength(50);

                    b.Property<int>("ManufacturerId");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("OsId");

                    b.Property<int>("Price");

                    b.Property<int>("Storage");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("OsId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eShop.Data.Entities.Product", b =>
                {
                    b.HasOne("eShop.Data.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eShop.Data.Entities.Os", "Os")
                        .WithMany("Products")
                        .HasForeignKey("OsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
