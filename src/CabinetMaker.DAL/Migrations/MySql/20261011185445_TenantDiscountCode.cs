using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetMaker.DAL.Migrations.MySql
{
    /// <inheritdoc />
    public partial class TenantDiscountCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DiscountCodes_DiscountTypeId",
                table: "DiscountCodes",
                column: "DiscountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountCodes_Type_DiscountTypeId",
                table: "DiscountCodes",
                column: "DiscountTypeId",
                principalTable: "Type",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountCodes_Type_DiscountTypeId",
                table: "DiscountCodes");

            migrationBuilder.DropIndex(
                name: "IX_DiscountCodes_DiscountTypeId",
                table: "DiscountCodes");
        }
    }
}
