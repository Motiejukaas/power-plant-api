using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerPlantApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbCollation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "PowerPlants",
                type: "nvarchar(max)",
                nullable: false,
                collation: "Latin1_General_100_CI_AI",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "PowerPlants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldCollation: "Latin1_General_100_CI_AI");
        }
    }
}
