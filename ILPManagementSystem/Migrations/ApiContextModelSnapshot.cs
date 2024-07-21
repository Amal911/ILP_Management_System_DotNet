﻿// <auto-generated />
using System;
using ILPManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ILPManagementSystem.Models.AssessmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AssessmentTypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AssessmentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssessmentTypeName = "Daily Assessment"
                        },
                        new
                        {
                            Id = 2,
                            AssessmentTypeName = "Live Assessment"
                        },
                        new
                        {
                            Id = 3,
                            AssessmentTypeName = "Case Study"
                        });
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

                    b.Property<int>("BatchTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<int>("ProgramId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BatchTypeId");

                    b.HasIndex("LocationId");

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

                    b.HasIndex("BatchId");

                    b.HasIndex("PhaseId");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BatchTypeName = "Technical"
                        },
                        new
                        {
                            Id = 2,
                            BatchTypeName = "BA"
                        });
                });

            modelBuilder.Entity("ILPManagementSystem.Models.DTO.CompletedAssessmentDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AssessmentId")
                        .HasColumnType("integer");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Score")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("SubmissionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TraineeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("CompletedAssessment");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.DocumentLinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AssessmentId")
                        .HasColumnType("integer");

                    b.Property<string>("DocumentUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("documentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DocumentLinks");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Leave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("LeaveDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LeaveDateFrom")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LeaveDateTo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumofDays")
                        .HasColumnType("integer");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TraineeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.LeaveApproval", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<int>("LeavesId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("LeaveApprovals");
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationName = "Trivandrum"
                        },
                        new
                        {
                            Id = 2,
                            LocationName = "Kochi"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhaseName = "E-Learning"
                        },
                        new
                        {
                            Id = 2,
                            PhaseName = "Tech Fundamentals"
                        },
                        new
                        {
                            Id = 3,
                            PhaseName = "Business Orientation"
                        });
                });

            modelBuilder.Entity("ILPManagementSystem.Models.PhaseAssessmentTypeMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AssessmentTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("BatchPhaseId")
                        .HasColumnType("integer");

                    b.Property<int>("Weightage")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentTypeId");

                    b.HasIndex("BatchPhaseId");

                    b.ToTable("PhaseAssessmentTypeMappings");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Trainer"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Trainee"
                        });
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

            modelBuilder.Entity("ILPManagementSystem.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("SessionDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SessionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("batchId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("programId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("trainerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Batch", b =>
                {
                    b.HasOne("ILPManagementSystem.Models.BatchType", "BatchType")
                        .WithMany("Batches")
                        .HasForeignKey("BatchTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILPManagementSystem.Models.Location", "Location")
                        .WithMany("Batches")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BatchType");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.BatchPhase", b =>
                {
                    b.HasOne("ILPManagementSystem.Models.Batch", "Batch")
                        .WithMany("BatchPhases")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILPManagementSystem.Models.Phase", "Phase")
                        .WithMany("BatchPhases")
                        .HasForeignKey("PhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Batch");

                    b.Navigation("Phase");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.PhaseAssessmentTypeMapping", b =>
                {
                    b.HasOne("ILPManagementSystem.Models.AssessmentType", "AssessmentType")
                        .WithMany("PhaseAssessmentTypeMappings")
                        .HasForeignKey("AssessmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ILPManagementSystem.Models.BatchPhase", "BatchPhase")
                        .WithMany("PhaseAssessmentTypeMappings")
                        .HasForeignKey("BatchPhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssessmentType");

                    b.Navigation("BatchPhase");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.User", b =>
                {
                    b.HasOne("ILPManagementSystem.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.AssessmentType", b =>
                {
                    b.Navigation("PhaseAssessmentTypeMappings");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Batch", b =>
                {
                    b.Navigation("BatchPhases");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.BatchPhase", b =>
                {
                    b.Navigation("PhaseAssessmentTypeMappings");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.BatchType", b =>
                {
                    b.Navigation("Batches");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Location", b =>
                {
                    b.Navigation("Batches");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Phase", b =>
                {
                    b.Navigation("BatchPhases");
                });

            modelBuilder.Entity("ILPManagementSystem.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
