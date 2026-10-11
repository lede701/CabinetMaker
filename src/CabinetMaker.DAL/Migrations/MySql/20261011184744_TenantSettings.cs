using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetMaker.DAL.Migrations.MySql
{
    /// <inheritdoc />
    public partial class TenantSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TenantSettings_TenantId",
                table: "TenantSettings",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantSettings_Tenants_TenantId",
                table: "TenantSettings",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantSettings_Tenants_TenantId",
                table: "TenantSettings");

            migrationBuilder.DropIndex(
                name: "IX_TenantSettings_TenantId",
                table: "TenantSettings");
        }
    }
}
