using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class updatepart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "numBegin",
                table: "TestQuestionUnits");

            migrationBuilder.DropColumn(
                name: "numEnd",
                table: "TestQuestionUnits");

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
                    { "1d1715a8-8d54-41df-9e90-8202c57b0526", "2", "Student", "Student" },
                    { "2b0ac2c4-a567-4bdc-b861-ca9c8d6fd295", "3", "VipStudent", "VipStudent" },
                    { "2b87b86c-7372-4829-b66d-1f9a92f33606", "1", "Admin", "Admin" },
                    { "9a156c66-22c8-419d-8ce5-6e6bf5393e6d", "4", "Professor", "Professor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestionUnits_idTest",
                table: "TestQuestionUnits",
                column: "idTest");

            migrationBuilder.AddForeignKey(
                name: "FK_UnitsOfTest",
                table: "TestQuestionUnits",
                column: "idTest",
                principalTable: "Tests",
                principalColumn: "idTest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UnitsOfTest",
                table: "TestQuestionUnits");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestionUnits_idTest",
                table: "TestQuestionUnits");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d1715a8-8d54-41df-9e90-8202c57b0526");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0ac2c4-a567-4bdc-b861-ca9c8d6fd295");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b87b86c-7372-4829-b66d-1f9a92f33606");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a156c66-22c8-419d-8ce5-6e6bf5393e6d");

            migrationBuilder.DropColumn(
                name: "idTest",
                table: "TestQuestionUnits");

            migrationBuilder.AddColumn<int>(
                name: "numBegin",
                table: "TestQuestionUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "numEnd",
                table: "TestQuestionUnits",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
