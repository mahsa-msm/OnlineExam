using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineExam.Infrastructures.DataLayer.Migrations
{
    public partial class blogsimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Blogs");
        }
    }
}
