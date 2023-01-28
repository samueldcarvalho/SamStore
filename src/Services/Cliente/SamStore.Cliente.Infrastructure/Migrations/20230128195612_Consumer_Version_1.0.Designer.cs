﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamStore.Cliente.Infrastructure.Contexts;

#nullable disable

namespace SamStore.Cliente.Infrastructure.Migrations
{
    [DbContext(typeof(ConsumerDbContext))]
    [Migration("20230128195612_Consumer_Version_1.0")]
    partial class Consumer_Version_10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SamStore.Cliente.Domain.Consumers.Consumer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("char(36)")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("name");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.HasKey("Id")
                        .HasName("pk_consumer");

                    b.ToTable("consumer", (string)null);
                });

            modelBuilder.Entity("SamStore.Cliente.Domain.Consumers.ConsumerAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<DateTime>("AlteredAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("altered_at");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("city");

                    b.Property<Guid>("ConsumerId")
                        .HasColumnType("char(36)")
                        .HasColumnName("consumer_id");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("DATETIME")
                        .HasColumnName("created_at");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("district");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("line1");

                    b.Property<string>("Line2")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("line2");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<bool>("Removed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("removed");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("state");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("zip_code");

                    b.HasKey("Id")
                        .HasName("pk_consumer_address");

                    b.HasIndex("ConsumerId")
                        .IsUnique()
                        .HasDatabaseName("ix_consumer_address_consumer_id");

                    b.ToTable("consumer_address", (string)null);
                });

            modelBuilder.Entity("SamStore.Cliente.Domain.Consumers.Consumer", b =>
                {
                    b.OwnsOne("SamStore.Core.Domain.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("ConsumerId")
                                .HasColumnType("char(36)")
                                .HasColumnName("id");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("VARCHAR(11)")
                                .HasColumnName("cpf");

                            b1.HasKey("ConsumerId");

                            b1.ToTable("consumer");

                            b1.WithOwner()
                                .HasForeignKey("ConsumerId")
                                .HasConstraintName("fk_consumer_consumer_id");
                        });

                    b.OwnsOne("SamStore.Core.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ConsumerId")
                                .HasColumnType("char(36)")
                                .HasColumnName("id");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)")
                                .HasColumnName("email");

                            b1.HasKey("ConsumerId");

                            b1.ToTable("consumer");

                            b1.WithOwner()
                                .HasForeignKey("ConsumerId")
                                .HasConstraintName("fk_consumer_consumer_id");
                        });

                    b.OwnsOne("SamStore.Core.Domain.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("ConsumerId")
                                .HasColumnType("char(36)")
                                .HasColumnName("id");

                            b1.Property<string>("PrincipalPhone")
                                .IsRequired()
                                .HasColumnType("VARCHAR(20)")
                                .HasColumnName("phone1");

                            b1.Property<string>("SecundaryPhone")
                                .IsRequired()
                                .HasColumnType("VARCHAR(20)")
                                .HasColumnName("phone2");

                            b1.HasKey("ConsumerId");

                            b1.ToTable("consumer");

                            b1.WithOwner()
                                .HasForeignKey("ConsumerId")
                                .HasConstraintName("fk_consumer_consumer_id");
                        });

                    b.Navigation("CPF")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("SamStore.Cliente.Domain.Consumers.ConsumerAddress", b =>
                {
                    b.HasOne("SamStore.Cliente.Domain.Consumers.Consumer", "Consumer")
                        .WithOne("ConsumerAddress")
                        .HasForeignKey("SamStore.Cliente.Domain.Consumers.ConsumerAddress", "ConsumerId")
                        .IsRequired()
                        .HasConstraintName("fk_consumer_address_products_consumer_id");

                    b.Navigation("Consumer");
                });

            modelBuilder.Entity("SamStore.Cliente.Domain.Consumers.Consumer", b =>
                {
                    b.Navigation("ConsumerAddress")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}