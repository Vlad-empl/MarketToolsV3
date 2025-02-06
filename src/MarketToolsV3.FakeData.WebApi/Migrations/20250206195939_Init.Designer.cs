﻿// <auto-generated />
using System;
using MarketToolsV3.FakeData.WebApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketToolsV3.FakeData.WebApi.Migrations
{
    [DbContext(typeof(FakeDataDbContext))]
    [Migration("20250206195939_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.FakeDataTask", b =>
                {
                    b.Property<string>("TaskId")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.HasKey("TaskId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.ResponseBody", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Data")
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)");

                    b.Property<int>("TaskDetailsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TaskDetailsId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.TaskDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("JsonBody")
                        .HasMaxLength(10000)
                        .HasColumnType("character varying(10000)");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("NumFailed")
                        .HasColumnType("integer");

                    b.Property<int>("NumGroup")
                        .HasColumnType("integer");

                    b.Property<int>("NumSuccessful")
                        .HasColumnType("integer");

                    b.Property<int>("NumberInQueue")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfExecutions")
                        .HasColumnType("integer");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("Tag")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("TaskCompleteCondition")
                        .HasColumnType("integer");

                    b.Property<string>("TaskId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("TimeoutBeforeRun")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("TasksDetails");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.ValueUseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("ResponseBodyId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusCode")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResponseBodyId");

                    b.ToTable("ValueUseHistories");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.ResponseBody", b =>
                {
                    b.HasOne("MarketToolsV3.FakeData.WebApi.Domain.Entities.TaskDetails", "TaskDetails")
                        .WithMany("Responses")
                        .HasForeignKey("TaskDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskDetails");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.TaskDetails", b =>
                {
                    b.HasOne("MarketToolsV3.FakeData.WebApi.Domain.Entities.FakeDataTask", "Task")
                        .WithMany("Details")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.ValueUseHistory", b =>
                {
                    b.HasOne("MarketToolsV3.FakeData.WebApi.Domain.Entities.ResponseBody", "ResponseBody")
                        .WithMany("ValueUseHistories")
                        .HasForeignKey("ResponseBodyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResponseBody");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.FakeDataTask", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.ResponseBody", b =>
                {
                    b.Navigation("ValueUseHistories");
                });

            modelBuilder.Entity("MarketToolsV3.FakeData.WebApi.Domain.Entities.TaskDetails", b =>
                {
                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}
