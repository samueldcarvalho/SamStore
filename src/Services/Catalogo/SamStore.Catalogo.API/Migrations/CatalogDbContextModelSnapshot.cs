﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamStore.Catalogo.API.Data.Contexts;

#nullable disable

namespace SamStore.Catalogo.API.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SamStore.Catalogo.API.Domain.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500)")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(250)")
                        .HasColumnName("name");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.Property<decimal>("Value")
                        .HasColumnType("DECIMAL(65,4)")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_product");

                    b.ToTable("product", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}