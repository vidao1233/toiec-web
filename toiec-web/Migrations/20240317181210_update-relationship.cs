using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toeic_web.Migrations
{
    public partial class updaterelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfProfessor",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonOfCourse",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsOfQuiz",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizzesOfLesson",
                table: "Quizs");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitsOfTest",
                table: "TestQuestionUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_VocOfTopic",
                table: "Vocabularies");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfProfessor",
                table: "Courses",
                column: "idProfessor",
                principalTable: "Professors",
                principalColumn: "idProfessor");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonOfCourse",
                table: "Lessons",
                column: "idCourse",
                principalTable: "Courses",
                principalColumn: "idCourse",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsOfQuiz",
                table: "Questions",
                column: "idQuiz",
                principalTable: "Quizs",
                principalColumn: "idQuiz",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzesOfLesson",
                table: "Quizs",
                column: "idLesson",
                principalTable: "Lessons",
                principalColumn: "idLesson",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsOfTest",
                table: "TestQuestionUnits",
                column: "idTest",
                principalTable: "Tests",
                principalColumn: "idTest",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VocOfTopic",
                table: "Vocabularies",
                column: "idTopic",
                principalTable: "VocabularyTopics",
                principalColumn: "idVocTopic",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseOfProfessor",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_LessonOfCourse",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsOfQuiz",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizzesOfLesson",
                table: "Quizs");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitsOfTest",
                table: "TestQuestionUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_VocOfTopic",
                table: "Vocabularies");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseOfProfessor",
                table: "Courses",
                column: "idProfessor",
                principalTable: "Professors",
                principalColumn: "idProfessor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LessonOfCourse",
                table: "Lessons",
                column: "idCourse",
                principalTable: "Courses",
                principalColumn: "idCourse",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsOfQuiz",
                table: "Questions",
                column: "idQuiz",
                principalTable: "Quizs",
                principalColumn: "idQuiz");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizzesOfLesson",
                table: "Quizs",
                column: "idLesson",
                principalTable: "Lessons",
                principalColumn: "idLesson");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsOfTest",
                table: "TestQuestionUnits",
                column: "idTest",
                principalTable: "Tests",
                principalColumn: "idTest");

            migrationBuilder.AddForeignKey(
                name: "FK_VocOfTopic",
                table: "Vocabularies",
                column: "idTopic",
                principalTable: "VocabularyTopics",
                principalColumn: "idVocTopic");
        }
    }
}
