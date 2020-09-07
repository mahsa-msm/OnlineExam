using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineExam.Infrastructures.DataLayer.Migrations
{
    public partial class AddIsCorrect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Answers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Answers");
        }
    }
}
