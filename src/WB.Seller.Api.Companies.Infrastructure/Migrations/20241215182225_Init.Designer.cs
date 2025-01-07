﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WB.Seller.Api.Companies.Infrastructure.Database;

#nullable disable

namespace WB.Seller.Api.Companies.Infrastructure.Migrations
{
    [DbContext(typeof(ApiCompaniesDbContext))]
    [Migration("20241215182225_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Owner", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId");

                    b.ToTable("owners", (string)null);
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.HasIndex("Type", "Status", "SubscriptionId")
                        .IsUnique();

                    b.ToTable("permissions", (string)null);
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Subscriber", b =>
                {
                    b.Property<string>("SubId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("SubId");

                    b.ToTable("subscribers", (string)null);
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SubscriberId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SubscriberId");

                    b.HasIndex("CompanyId", "SubscriberId")
                        .IsUnique();

                    b.ToTable("subscriptions", (string)null);
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Company", b =>
                {
                    b.HasOne("WB.Seller.Api.Companies.Domain.Entities.Owner", "Owner")
                        .WithMany("Companies")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Permission", b =>
                {
                    b.HasOne("WB.Seller.Api.Companies.Domain.Entities.Subscription", "Subscription")
                        .WithMany("Permissions")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Subscription", b =>
                {
                    b.HasOne("WB.Seller.Api.Companies.Domain.Entities.Company", "Company")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WB.Seller.Api.Companies.Domain.Entities.Subscriber", "Subscriber")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Company", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Owner", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Subscriber", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("WB.Seller.Api.Companies.Domain.Entities.Subscription", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
