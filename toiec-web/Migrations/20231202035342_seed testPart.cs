using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class seedtestPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartOfTest",
                table: "TestParts");

            migrationBuilder.DropIndex(
                name: "IX_TestParts_testId",
                table: "TestParts");

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
                name: "testId",
                table: "TestParts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a4dac25-cb46-4f59-9d0c-0040f0fe561e", "4", "Professor", "Professor" },
                    { "41781a68-9755-46aa-9da5-ca503d7f9995", "2", "Student", "Student" },
                    { "8057d908-aaa3-456a-b35f-a921447f5332", "3", "VipStudent", "VipStudent" },
                    { "8e97bf67-6a0f-448e-bd48-ba577ec2172e", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { 1, "Part 1" },
                    { 2, "Part 2" },
                    { 3, "Part 3" },
                    { 4, "Part 4" },
                    { 5, "Part 5" },
                    { 6, "Part 6" },
                    { 7, "Part 7" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a4dac25-cb46-4f59-9d0c-0040f0fe561e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41781a68-9755-46aa-9da5-ca503d7f9995");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8057d908-aaa3-456a-b35f-a921447f5332");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e97bf67-6a0f-448e-bd48-ba577ec2172e");

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: 7);

            migrationBuilder.AddColumn<Guid>(
                name: "testId",
                table: "TestParts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                name: "IX_TestParts_testId",
                table: "TestParts",
                column: "testId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartOfTest",
                table: "TestParts",
                column: "testId",
                principalTable: "Tests",
                principalColumn: "idTest",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
