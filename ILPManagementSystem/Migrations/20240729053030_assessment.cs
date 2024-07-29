using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class assessment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Trainers_TrainerId",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Assessments",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Assessments_TrainerId",
                table: "Assessments",
                newName: "IX_Assessments_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionTime",
                table: "CompletedAssessment",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "CompletedAssessment",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "CompletedAssessment",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "CompletedAssessment",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "CompletedAssessment",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalScore",
                table: "Assessments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDateTime",
                table: "Assessments",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assessments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Assessments",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Assessments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DocumentContentType",
                table: "Assessments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentName",
                table: "Assessments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                table: "Assessments",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhaseId",
                table: "Assessments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompletedAssessment_AssessmentId",
                table: "CompletedAssessment",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_BatchId",
                table: "Assessments",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_PhaseId",
                table: "Assessments",
                column: "PhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Batchs_BatchId",
                table: "Assessments",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Phases_PhaseId",
                table: "Assessments",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Users_UserId",
                table: "Assessments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompletedAssessment_Assessments_AssessmentId",
                table: "CompletedAssessment",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Batchs_BatchId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Phases_PhaseId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_Users_UserId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_CompletedAssessment_Assessments_AssessmentId",
                table: "CompletedAssessment");

            migrationBuilder.DropIndex(
                name: "IX_CompletedAssessment_AssessmentId",
                table: "CompletedAssessment");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_BatchId",
                table: "Assessments");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_PhaseId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "CompletedAssessment");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "CompletedAssessment");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "DocumentContentType",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "DocumentName",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "DocumentPath",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "PhaseId",
                table: "Assessments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Assessments",
                newName: "TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Assessments_UserId",
                table: "Assessments",
                newName: "IX_Assessments_TrainerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionTime",
                table: "CompletedAssessment",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "CompletedAssessment",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "CompletedAssessment",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalScore",
                table: "Assessments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDateTime",
                table: "Assessments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assessments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Assessments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_Trainers_TrainerId",
                table: "Assessments",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
