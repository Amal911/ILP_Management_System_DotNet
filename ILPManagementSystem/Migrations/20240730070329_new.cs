using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:ILPManagementSystem/Migrations/20240730070329_new.cs
    public partial class @new : Migration
========
    public partial class update : Migration
>>>>>>>> a496a6be9d77edf637fc745a43a61bd3ac5096fc:ILPManagementSystem/Migrations/20240730051356_update.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssessmentTypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    TraineeId = table.Column<int>(type: "integer", nullable: false),
                    IsPresent = table.Column<bool>(type: "boolean", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatchTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchTypeName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssessmentId = table.Column<int>(type: "integer", nullable: false),
                    DocumentUrl = table.Column<string>(type: "text", nullable: false),
                    documentType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhaseName = table.Column<string>(type: "text", nullable: false),
                    PhaseDuration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProgramName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scorecards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DailyAssessment = table.Column<int>(type: "integer", nullable: false),
                    LiveAssessment = table.Column<int>(type: "integer", nullable: false),
                    ModuleAssessment = table.Column<int>(type: "integer", nullable: false),
                    CaseStudy = table.Column<int>(type: "integer", nullable: false),
                    Project = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scorecards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessionAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    TraineeId = table.Column<int>(type: "integer", nullable: false),
                    Attendance = table.Column<bool>(type: "boolean", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionAttendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionName = table.Column<string>(type: "text", nullable: false),
                    SessionDescription = table.Column<string>(type: "text", nullable: false),
                    startTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BatchId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Batchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchName = table.Column<string>(type: "text", nullable: false),
                    BatchCode = table.Column<string>(type: "text", nullable: false),
                    BatchDuration = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ProgramId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    BatchTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batchs_BatchTypes_BatchTypeId",
                        column: x => x.BatchTypeId,
                        principalTable: "BatchTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Batchs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Batchs_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailId = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatchPhase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumberOfDays = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    BatchId = table.Column<int>(type: "integer", nullable: false),
                    PhaseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchPhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatchPhase_Batchs_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatchPhase_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BatchId = table.Column<int>(type: "integer", nullable: false),
                    PhaseId = table.Column<int>(type: "integer", nullable: false),
                    AssessmentTitle = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TotalScore = table.Column<int>(type: "integer", nullable: true),
                    IsSubmitable = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AssessmentTypeID = table.Column<int>(type: "integer", nullable: false),
                    DueDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DocumentPath = table.Column<string>(type: "text", nullable: true),
                    DocumentName = table.Column<string>(type: "text", nullable: true),
                    DocumentContentType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_AssessmentTypes_AssessmentTypeID",
                        column: x => x.AssessmentTypeID,
                        principalTable: "AssessmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assessments_Batchs_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assessments_Phases_PhaseId",
                        column: x => x.PhaseId,
                        principalTable: "Phases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assessments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BatchId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Batchs_BatchId",
                        column: x => x.BatchId,
                        principalTable: "Batchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhaseAssessmentTypeMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weightage = table.Column<int>(type: "integer", nullable: false),
                    AssessmentTypeId = table.Column<int>(type: "integer", nullable: false),
                    BatchPhaseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhaseAssessmentTypeMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhaseAssessmentTypeMappings_AssessmentTypes_AssessmentTypeId",
                        column: x => x.AssessmentTypeId,
                        principalTable: "AssessmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhaseAssessmentTypeMappings_BatchPhase_BatchPhaseId",
                        column: x => x.BatchPhaseId,
                        principalTable: "BatchPhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompletedAssessment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AssessmentId = table.Column<int>(type: "integer", nullable: false),
                    TraineeId = table.Column<int>(type: "integer", nullable: false),
                    Score = table.Column<double>(type: "double precision", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    SubmissionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletedAssessment_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TraineeId = table.Column<int>(type: "integer", nullable: false),
                    NumofDays = table.Column<int>(type: "integer", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveDateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeaveDateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApprovals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LeavesId = table.Column<int>(type: "integer", nullable: false),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApprovals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveApprovals_Leaves_LeavesId",
                        column: x => x.LeavesId,
                        principalTable: "Leaves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveApprovals_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AssessmentTypes",
                columns: new[] { "Id", "AssessmentTypeName" },
                values: new object[,]
                {
                    { 1, "Daily Assessment" },
                    { 2, "Live Assessment" },
                    { 3, "Case Study" }
                });

            migrationBuilder.InsertData(
                table: "BatchTypes",
                columns: new[] { "Id", "BatchTypeName" },
                values: new object[,]
                {
                    { 1, "Technical" },
                    { 2, "BA" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "LocationName" },
                values: new object[,]
                {
                    { 1, "Trivandrum" },
                    { 2, "Kochi" }
                });

            migrationBuilder.InsertData(
                table: "Phases",
                columns: new[] { "Id", "PhaseDuration", "PhaseName" },
                values: new object[,]
                {
                    { 1, 20, "E-Learning" },
                    { 2, 40, "Tech Fundamentals" },
                    { 3, 30, "Business Orientation" }
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "ProgramName" },
                values: new object[,]
                {
                    { 1, "2023-2024" },
                    { 2, "2024-2025" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Trainer" },
                    { 3, "Trainee" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailId", "FirstName", "Gender", "IsActive", "LastName", "MobileNumber", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "amal_admin@sreegcloudgmail.onmicrosoft.com", "Amal", 1, true, "Admin", "1234567890", "Gowo690819", 1 },
                    { 2, "devipriya_admin@sreegcloudgmail.onmicrosoft.com", "Devipriya", 2, true, "Admin", "1234567891", "Vajo021247", 1 },
                    { 3, "suneesh.thampi@sreegcloudgmail.onmicrosoft.com", "Suneesh", 1, true, "Thampi", "1234567892", "Huna544047", 2 },
                    { 4, "lekshmi.a@sreegcloudgmail.onmicrosoft.com", "Lekshmi", 2, true, "A", "1234567893", "Quwu856933", 2 },
                    { 5, "jisna.george@sreegcloudgmail.onmicrosoft.com", "Jisna", 2, true, "George", "1234567894", "Koso191442", 3 },
                    { 6, "thulasi.k@sreegcloudgmail.onmicrosoft.com", "Thulasi", 2, true, "K", "1234567895", "Toqo391712", 3 },
                    { 7, "dharsan.sajeev@sreegcloudgmail.onmicrosoft.com", "Dharsan", 1, true, "Sajeev", "1234567896", "Zuja977409", 3 }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "userId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserId",
                table: "Admin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AssessmentTypeID",
                table: "Assessments",
                column: "AssessmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_BatchId",
                table: "Assessments",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_PhaseId",
                table: "Assessments",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_UserId",
                table: "Assessments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchPhase_BatchId",
                table: "BatchPhase",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchPhase_PhaseId",
                table: "BatchPhase",
                column: "PhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_BatchTypeId",
                table: "Batchs",
                column: "BatchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_LocationId",
                table: "Batchs",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Batchs_ProgramId",
                table: "Batchs",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_CompletedAssessment_AssessmentId",
                table: "CompletedAssessment",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_LeavesId",
                table: "LeaveApprovals",
                column: "LeavesId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApprovals_userId",
                table: "LeaveApprovals",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_TraineeId",
                table: "Leaves",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseAssessmentTypeMappings_AssessmentTypeId",
                table: "PhaseAssessmentTypeMappings",
                column: "AssessmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseAssessmentTypeMappings_BatchPhaseId",
                table: "PhaseAssessmentTypeMappings",
                column: "BatchPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_BatchId",
                table: "Trainees",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_UserId",
                table: "Trainees",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_userId",
                table: "Trainers",
                column: "userId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "CompletedAssessment");

            migrationBuilder.DropTable(
                name: "DocumentLinks");

            migrationBuilder.DropTable(
                name: "LeaveApprovals");

            migrationBuilder.DropTable(
                name: "PhaseAssessmentTypeMappings");

            migrationBuilder.DropTable(
                name: "Scorecards");

            migrationBuilder.DropTable(
                name: "SessionAttendances");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "BatchPhase");

            migrationBuilder.DropTable(
                name: "AssessmentTypes");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Phases");

            migrationBuilder.DropTable(
                name: "Batchs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BatchTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
