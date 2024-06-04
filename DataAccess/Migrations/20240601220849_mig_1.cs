using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriers_Orders_OrderId",
                table: "Carriers");

            migrationBuilder.DropIndex(
                name: "IX_Carriers_OrderId",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Carriers");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarrierId",
                table: "Orders",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carriers_CarrierId",
                table: "Orders",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "CarrierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carriers_CarrierId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CarrierId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Carriers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carriers_OrderId",
                table: "Carriers",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carriers_Orders_OrderId",
                table: "Carriers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
