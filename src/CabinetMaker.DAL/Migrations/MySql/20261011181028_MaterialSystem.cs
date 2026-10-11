using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetMaker.DAL.Migrations.MySql
{
    /// <inheritdoc />
    public partial class MaterialSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CmMaterialAttributreId",
                table: "MaterialAttributes",
                newName: "CmMaterialAttributeId");

            migrationBuilder.AddColumn<Guid>(
                name: "CmMaterialGuid",
                table: "Materials",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "HasGrainDirection",
                table: "Materials",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystemMaterial",
                table: "Materials",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaterialCategoryTypeId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MaterialDetails",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<Guid>(
                name: "CmMaterialDetailGuid",
                table: "MaterialDetails",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "CmMaterialId",
                table: "MaterialDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitCost",
                table: "MaterialDetails",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WasteFactorPercentage",
                table: "MaterialDetails",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "CmMaterialAttributeGuid",
                table: "MaterialAttributes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MaterialAttributes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "MaterialAttributes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "MaterialAttributes",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastUpdatedUserId",
                table: "MaterialAttributes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStateId",
                table: "MaterialAttributes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaterialDetails_CmMaterialId",
                table: "MaterialDetails",
                column: "CmMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialAttributes_CmMaterialId",
                table: "MaterialAttributes",
                column: "CmMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialAttributes_Materials_CmMaterialId",
                table: "MaterialAttributes",
                column: "CmMaterialId",
                principalTable: "Materials",
                principalColumn: "CmMaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialDetails_Materials_CmMaterialId",
                table: "MaterialDetails",
                column: "CmMaterialId",
                principalTable: "Materials",
                principalColumn: "CmMaterialId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialAttributes_Materials_CmMaterialId",
                table: "MaterialAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialDetails_Materials_CmMaterialId",
                table: "MaterialDetails");

            migrationBuilder.DropIndex(
                name: "IX_MaterialDetails_CmMaterialId",
                table: "MaterialDetails");

            migrationBuilder.DropIndex(
                name: "IX_MaterialAttributes_CmMaterialId",
                table: "MaterialAttributes");

            migrationBuilder.DropColumn(
                name: "CmMaterialGuid",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "HasGrainDirection",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "IsSystemMaterial",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MaterialCategoryTypeId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "CmMaterialDetailGuid",
                table: "MaterialDetails");

            migrationBuilder.DropColumn(
                name: "CmMaterialId",
                table: "MaterialDetails");

            migrationBuilder.DropColumn(
                name: "UnitCost",
                table: "MaterialDetails");

            migrationBuilder.DropColumn(
                name: "WasteFactorPercentage",
                table: "MaterialDetails");

            migrationBuilder.DropColumn(
                name: "CmMaterialAttributeGuid",
                table: "MaterialAttributes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MaterialAttributes");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "MaterialAttributes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "MaterialAttributes");

            migrationBuilder.DropColumn(
                name: "LastUpdatedUserId",
                table: "MaterialAttributes");

            migrationBuilder.DropColumn(
                name: "RecordStateId",
                table: "MaterialAttributes");

            migrationBuilder.RenameColumn(
                name: "CmMaterialAttributeId",
                table: "MaterialAttributes",
                newName: "CmMaterialAttributreId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MaterialDetails",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);
        }
    }
}
