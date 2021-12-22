using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketingTask.Migrations
{
    public partial class TotalProductPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalSoldProductPrice",
                table: "DistributorSales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSoldProductPrice",
                table: "DistributorSales");
        }
    }
}
