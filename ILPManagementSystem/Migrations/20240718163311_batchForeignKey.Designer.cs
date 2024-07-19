﻿// <auto-generated />
using System;
using ILPManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20240718163311_batchForeignKey")]
    partial class batchForeignKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ILPManagementSystem.Models.Assessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AssessmentTitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AssessmentTypeID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DueDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsSubmitable")
                        .HasColumnType("boolean");

                    b.Property<int>("TotalScore")
                        .HasColumnType("integer");

                    b.Property<int>("TrainerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Batch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BatchCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BatchDuration")
                        .HasColumnType("integer");

                    b.Property<string>("BatchName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("LocationId1")
                        .HasColumnType("integer");

                    b.Property<int>("ProgramId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("batchId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocationId1");

                    b.ToTable("Batchs");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.BatchPhase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BatchId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("integer");

                    b.Property<int>("PhaseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("BatchPhase");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.BatchType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BatchTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BatchTypes");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Phase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PhaseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Phases");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Scorecard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CaseStudy")
                        .HasColumnType("integer");

                    b.Property<int>("DailyAssessment")
                        .HasColumnType("integer");

                    b.Property<int>("LiveAssessment")
                        .HasColumnType("integer");

                    b.Property<int>("ModuleAssessment")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Project")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Scorecards");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Batch", b =>
                {
                    b.HasOne("ILPManagementSystem.Models.Location", "Location")
                        .WithMany("Batches")
                        .HasForeignKey("LocationId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Location", b =>
                {
                    b.Navigation("Batches");
                });
#pragma warning restore 612, 618
        }
    }
}
