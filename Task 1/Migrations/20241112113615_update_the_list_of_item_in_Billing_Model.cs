using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_1.Migrations
{
    /// <inheritdoc />
    public partial class update_the_list_of_item_in_Billing_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Billing_BillingId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_BillingId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BillingId",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillingId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_BillingId",
                table: "Items",
                column: "BillingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Billing_BillingId",
                table: "Items",
                column: "BillingId",
                principalTable: "Billing",
                principalColumn: "Id");
        }
    }
}
