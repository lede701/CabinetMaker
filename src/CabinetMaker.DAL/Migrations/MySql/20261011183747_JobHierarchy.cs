using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetMaker.DAL.Migrations.MySql
{
    /// <inheritdoc />
    public partial class JobHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OperationParametersJson",
                table: "PartOperations",
                type: "json",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_AssemblyId",
                table: "Parts",
                column: "AssemblyId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_MaterialId",
                table: "Parts",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PartOperations_PartId",
                table: "PartOperations",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEstimates_JobId",
                table: "JobEstimates",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Assembly_JobId",
                table: "Assembly",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assembly_Jobs_JobId",
                table: "Assembly",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEstimates_Jobs_JobId",
                table: "JobEstimates",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "JobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOperations_Parts_PartId",
                table: "PartOperations",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "PartId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Assembly_AssemblyId",
                table: "Parts",
                column: "AssemblyId",
                principalTable: "Assembly",
                principalColumn: "AssemblyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Materials_MaterialId",
                table: "Parts",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "CmMaterialId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assembly_Jobs_JobId",
                table: "Assembly");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEstimates_Jobs_JobId",
                table: "JobEstimates");

            migrationBuilder.DropForeignKey(
                name: "FK_PartOperations_Parts_PartId",
                table: "PartOperations");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Assembly_AssemblyId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Materials_MaterialId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_AssemblyId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_MaterialId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_PartOperations_PartId",
                table: "PartOperations");

            migrationBuilder.DropIndex(
                name: "IX_JobEstimates_JobId",
                table: "JobEstimates");

            migrationBuilder.DropIndex(
                name: "IX_Assembly_JobId",
                table: "Assembly");

            migrationBuilder.AlterColumn<string>(
                name: "OperationParametersJson",
                table: "PartOperations",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "json");
        }
    }
}
