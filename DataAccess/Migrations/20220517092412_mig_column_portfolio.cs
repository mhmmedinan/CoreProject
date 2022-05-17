using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_column_portfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image4",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Portfolios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Portfolios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Portfolios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image1",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Image4",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Portfolios");
        }
    }
}
