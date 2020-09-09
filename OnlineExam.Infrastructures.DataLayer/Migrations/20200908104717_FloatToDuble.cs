using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineExam.Infrastructures.DataLayer.Migrations
{
    public partial class FloatToDuble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Results",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Score",
                table: "Results",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
