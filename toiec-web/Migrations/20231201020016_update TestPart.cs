using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class updateTestPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsOfTest",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfTest",
                table: "TestQuestionUnits");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestionUnits_idTest",
                table: "TestQuestionUnits");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a38943-e9a3-42ef-8a5f-13ca002c6dcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30743ecc-bd50-4533-861f-0a0d2470da54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdb9e61b-00a7-45e4-ba57-c9ade5881eb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c12f603d-3788-4e79-b883-1569ae3d52aa");

            migrationBuilder.DropColumn(
                name: "idTest",
                table: "TestQuestionUnits");

            migrationBuilder.RenameColumn(
                name: "idTest",
                table: "Questions",
                newName: "idUnit");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_idTest",
                table: "Questions",
                newName: "IX_Questions_idUnit");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "idTestPart",
                table: "TestQuestionUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "idQuestion",
                table: "AnswerQuestions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TestParts",
                columns: table => new
                {
                    partId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    testId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    partName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestParts", x => x.partId);
                    table.ForeignKey(
                        name: "FK_PartOfTest",
                        column: x => x.testId,
                        principalTable: "Tests",
                        principalColumn: "idTest",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "184c7ab1-87ef-4333-95f6-fedbac47c6dc", "4", "Professor", "Professor" },
                    { "c55ac6d1-8b1a-44be-b527-93f1b788010d", "2", "Student", "Student" },
                    { "df55f3b9-870c-4d2d-bc36-9ab8d1c723b8", "3", "VipStudent", "VipStudent" },
                    { "f423aa16-90a3-4bde-824d-1b74cb714839", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestionUnits_idTestPart",
                table: "TestQuestionUnits",
                column: "idTestPart");

            migrationBuilder.CreateIndex(
                name: "IX_TestParts_testId",
                table: "TestParts",
                column: "testId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsOfUnit",
                table: "Questions",
                column: "idUnit",
                principalTable: "TestQuestionUnits",
                principalColumn: "idQuestionUnit",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfTestPart",
                table: "TestQuestionUnits",
                column: "idTestPart",
                principalTable: "TestParts",
                principalColumn: "partId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsOfUnit",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UnitOfTestPart",
                table: "TestQuestionUnits");

            migrationBuilder.DropTable(
                name: "TestParts");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestionUnits_idTestPart",
                table: "TestQuestionUnits");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "184c7ab1-87ef-4333-95f6-fedbac47c6dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c55ac6d1-8b1a-44be-b527-93f1b788010d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df55f3b9-870c-4d2d-bc36-9ab8d1c723b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f423aa16-90a3-4bde-824d-1b74cb714839");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "idTestPart",
                table: "TestQuestionUnits");

            migrationBuilder.DropColumn(
                name: "idQuestion",
                table: "AnswerQuestions");

            migrationBuilder.RenameColumn(
                name: "idUnit",
                table: "Questions",
                newName: "idTest");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_idUnit",
                table: "Questions",
                newName: "IX_Questions_idTest");

            migrationBuilder.AddColumn<Guid>(
                name: "idTest",
                table: "TestQuestionUnits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27a38943-e9a3-42ef-8a5f-13ca002c6dcc", "3", "VipStudent", "VipStudent" },
                    { "30743ecc-bd50-4533-861f-0a0d2470da54", "1", "Admin", "Admin" },
                    { "bdb9e61b-00a7-45e4-ba57-c9ade5881eb6", "2", "Student", "Student" },
                    { "c12f603d-3788-4e79-b883-1569ae3d52aa", "4", "Professor", "Professor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestionUnits_idTest",
                table: "TestQuestionUnits",
                column: "idTest");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsOfTest",
                table: "Questions",
                column: "idTest",
                principalTable: "Tests",
                principalColumn: "idTest");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitOfTest",
                table: "TestQuestionUnits",
                column: "idTest",
                principalTable: "Tests",
                principalColumn: "idTest");
        }
    }
}
