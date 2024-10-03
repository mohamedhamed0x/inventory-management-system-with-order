using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryOrder.Migrations
{
    /// <inheritdoc />
    public partial class edit1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Payments",
                newName: "PayeeName");

            migrationBuilder.AddColumn<int>(
                name: "InstallmentCount",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCash",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextInstallmentDate",
                table: "Payments",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallmentCount",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "IsCash",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "NextInstallmentDate",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "PayeeName",
                table: "Payments",
                newName: "PaymentType");
        }
    }
}
