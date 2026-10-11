using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetMaker.DAL.Migrations.MySql
{
    /// <inheritdoc />
    public partial class JobEstimate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobEstimateLines_JobEstimateId",
                table: "JobEstimateLines",
                column: "JobEstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEstimateLines_PartId",
                table: "JobEstimateLines",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_JobEstimateLines_TenantDiscountCodeId",
                table: "JobEstimateLines",
                column: "TenantDiscountCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobEstimateLines_DiscountCodes_TenantDiscountCodeId",
                table: "JobEstimateLines",
                column: "TenantDiscountCodeId",
                principalTable: "DiscountCodes",
                principalColumn: "TenantDiscountCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobEstimateLines_JobEstimates_JobEstimateId",
                table: "JobEstimateLines",
                column: "JobEstimateId",
                principalTable: "JobEstimates",
                principalColumn: "JobEstimateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobEstimateLines_Parts_PartId",
                table: "JobEstimateLines",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "PartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobEstimateLines_DiscountCodes_TenantDiscountCodeId",
                table: "JobEstimateLines");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEstimateLines_JobEstimates_JobEstimateId",
                table: "JobEstimateLines");

            migrationBuilder.DropForeignKey(
                name: "FK_JobEstimateLines_Parts_PartId",
                table: "JobEstimateLines");

            migrationBuilder.DropIndex(
                name: "IX_JobEstimateLines_JobEstimateId",
                table: "JobEstimateLines");

            migrationBuilder.DropIndex(
                name: "IX_JobEstimateLines_PartId",
                table: "JobEstimateLines");

            migrationBuilder.DropIndex(
                name: "IX_JobEstimateLines_TenantDiscountCodeId",
                table: "JobEstimateLines");
        }
    }
}
