using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ILPManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class batchTableForeignKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhaseId",
                table: "PhaseAssessmentTypeMappings",
                newName: "BatchPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseAssessmentTypeMappings_AssessmentTypeId",
                table: "PhaseAssessmentTypeMappings",
                column: "AssessmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhaseAssessmentTypeMappings_BatchPhaseId",
                table: "PhaseAssessmentTypeMappings",
                column: "BatchPhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchPhase_BatchId",
                table: "BatchPhase",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_BatchPhase_PhaseId",
                table: "BatchPhase",
                column: "PhaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchPhase_Batchs_BatchId",
                table: "BatchPhase",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BatchPhase_Phases_PhaseId",
                table: "BatchPhase",
                column: "PhaseId",
                principalTable: "Phases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhaseAssessmentTypeMappings_AssessmentTypes_AssessmentTypeId",
                table: "PhaseAssessmentTypeMappings",
                column: "AssessmentTypeId",
                principalTable: "AssessmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhaseAssessmentTypeMappings_BatchPhase_BatchPhaseId",
                table: "PhaseAssessmentTypeMappings",
                column: "BatchPhaseId",
                principalTable: "BatchPhase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchPhase_Batchs_BatchId",
                table: "BatchPhase");

            migrationBuilder.DropForeignKey(
                name: "FK_BatchPhase_Phases_PhaseId",
                table: "BatchPhase");

            migrationBuilder.DropForeignKey(
                name: "FK_PhaseAssessmentTypeMappings_AssessmentTypes_AssessmentTypeId",
                table: "PhaseAssessmentTypeMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_PhaseAssessmentTypeMappings_BatchPhase_BatchPhaseId",
                table: "PhaseAssessmentTypeMappings");

            migrationBuilder.DropIndex(
                name: "IX_PhaseAssessmentTypeMappings_AssessmentTypeId",
                table: "PhaseAssessmentTypeMappings");

            migrationBuilder.DropIndex(
                name: "IX_PhaseAssessmentTypeMappings_BatchPhaseId",
                table: "PhaseAssessmentTypeMappings");

            migrationBuilder.DropIndex(
                name: "IX_BatchPhase_BatchId",
                table: "BatchPhase");

            migrationBuilder.DropIndex(
                name: "IX_BatchPhase_PhaseId",
                table: "BatchPhase");

            migrationBuilder.RenameColumn(
                name: "BatchPhaseId",
                table: "PhaseAssessmentTypeMappings",
                newName: "PhaseId");
        }
    }
}
