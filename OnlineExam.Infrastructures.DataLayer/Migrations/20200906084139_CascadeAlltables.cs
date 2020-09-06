using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineExam.Infrastructures.DataLayer.Migrations
{
    public partial class CascadeAlltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionChoices_Choices_ChoiceId",
                table: "QuestionChoices");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionChoices_Questions_QuestionId",
                table: "QuestionChoices");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionChoices_Choices_ChoiceId",
                table: "QuestionChoices",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionChoices_Questions_QuestionId",
                table: "QuestionChoices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionChoices_Choices_ChoiceId",
                table: "QuestionChoices");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionChoices_Questions_QuestionId",
                table: "QuestionChoices");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Exams_ExamId",
                table: "ExamQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Questions_QuestionId",
                table: "ExamQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionChoices_Choices_ChoiceId",
                table: "QuestionChoices",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionChoices_Questions_QuestionId",
                table: "QuestionChoices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
