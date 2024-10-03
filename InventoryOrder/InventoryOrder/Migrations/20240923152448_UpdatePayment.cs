using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryOrder.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Orders");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPay",
                table: "Purchases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRefund",
                table: "Purchases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPay",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalRefund",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PaymentCustmoers",
                columns: table => new
                {
                    PaymentCustmoerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paymentdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentCustmoers", x => x.PaymentCustmoerID);
                    table.ForeignKey(
                        name: "FK_PaymentCustmoers_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    
                    table.ForeignKey(
                        name: "FK_PaymentCustmoers_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                 
                });

            migrationBuilder.CreateTable(
                name: "PaymentSuppliers",
                columns: table => new
                {
                    PaymentSupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paymentdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseID = table.Column<int>(type: "int", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentSuppliers", x => x.PaymentSupplierID);
                    table.ForeignKey(
                        name: "FK_PaymentSuppliers_Purchases_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseID",
                        onDelete: ReferentialAction.Restrict);
               
                    table.ForeignKey(
                        name: "FK_PaymentSuppliers_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
       
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCustmoers_CustomerID",
                table: "PaymentCustmoers",
                column: "CustomerID");

        

            migrationBuilder.CreateIndex(
                name: "IX_PaymentCustmoers_OrderID",
                table: "PaymentCustmoers",
                column: "OrderID");

         
            migrationBuilder.CreateIndex(
                name: "IX_PaymentSuppliers_PurchaseID",
                table: "PaymentSuppliers",
                column: "PurchaseID");

         

            migrationBuilder.CreateIndex(
                name: "IX_PaymentSuppliers_SupplierID",
                table: "PaymentSuppliers",
                column: "SupplierID");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentCustmoers");

            migrationBuilder.DropTable(
                name: "PaymentSuppliers");

            migrationBuilder.DropColumn(
                name: "TotalPay",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "TotalRefund",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "TotalPay",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalRefund",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Purchases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    PurchaseID = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InstallmentCount = table.Column<int>(type: "int", nullable: true),
                    IsCash = table.Column<bool>(type: "bit", nullable: false),
                    IsCustomerPayment = table.Column<bool>(type: "bit", nullable: false),
                    NextInstallmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderID1 = table.Column<int>(type: "int", nullable: true),
                    PayeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderID1",
                        column: x => x.OrderID1,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Payments_Purchases_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Purchases_PurchaseID1",
                        column: x => x.PurchaseID1,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderID",
                table: "Payments",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderID1",
                table: "Payments",
                column: "OrderID1");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PurchaseID",
                table: "Payments",
                column: "PurchaseID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PurchaseID1",
                table: "Payments",
                column: "PurchaseID1");
        }
    }
}
