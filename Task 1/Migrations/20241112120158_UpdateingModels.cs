using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpBills");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Billing",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Billing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Billing_EmployeeId",
                table: "Billing",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billing_Employees_EmployeeId",
                table: "Billing",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billing_Employees_EmployeeId",
                table: "Billing");

            migrationBuilder.DropIndex(
                name: "IX_Billing_EmployeeId",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Billing");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Billing");

            migrationBuilder.CreateTable(
                name: "EmpBills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpBills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpBills_Billing_BillingId",
                        column: x => x.BillingId,
                        principalTable: "Billing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpBills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpBills_BillingId",
                table: "EmpBills",
                column: "BillingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpBills_EmployeeId",
                table: "EmpBills",
                column: "EmployeeId");
        }
    }
}
