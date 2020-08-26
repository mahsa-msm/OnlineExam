using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineExam.Infrastructures.DataLayer.Migrations
{
    public partial class initAddIsCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Choices",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Choices");
        }
    }
}
