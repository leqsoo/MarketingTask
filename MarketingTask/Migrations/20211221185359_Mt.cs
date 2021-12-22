using Microsoft.EntityFrameworkCore.Migrations;

namespace MarketingTask.Migrations
{
    public partial class Mt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalSoldAmount",
                table: "DistributorSales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSoldAmount",
                table: "DistributorSales");
        }
    }
}
