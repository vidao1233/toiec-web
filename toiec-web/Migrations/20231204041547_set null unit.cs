using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class setnullunit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03d370ff-a4f1-4dc1-8943-1e7e5f550986");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a4199fb-2238-42a7-b713-bc96be5b05aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc8b3d09-e5d8-4bbb-8d68-d624db8f91c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb0d5c9f-e0e6-44d5-b4b0-09e14379c8d5");

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("ab205728-050d-4c22-93b6-4171d0dbefe5"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("b0817960-09d4-445d-a9bf-62a5327c584a"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("b5450201-44a4-48b7-9773-49c86ded2335"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("c15ff8d6-3a57-40de-a196-c697d62fd490"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("c2e10783-0588-4c0a-99b0-d698bde0a070"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("ca835428-6ebc-4f65-82f7-d6d17f1954e3"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("dad8b106-b3ff-4b11-8086-c1f05ae5e58d"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("6816bbf3-5fc2-436c-a66d-38b0527f300e"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("a78210d6-5920-49fe-84d1-467111e86507"));

            migrationBuilder.AlterColumn<string>(
                name: "translation",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "script",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "paragraph",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "audio",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "219d1cd9-c977-4e52-954c-f19bd89dd84b", "1", "Admin", "Admin" },
                    { "22023ea6-74ae-4f0f-8694-ef7476ffb0d1", "2", "Student", "Student" },
                    { "8a98e1ff-2f3f-4dc1-8983-faeb0d7c6337", "3", "VipStudent", "VipStudent" },
                    { "a4538cf6-b28c-4382-bde7-586e5b4ac867", "4", "Professor", "Professor" }
                });

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { new Guid("18b74324-6ce9-4285-9943-302cf23edbd6"), "Part 3" },
                    { new Guid("64f8b840-9a17-4fef-b940-3fed9e7a5756"), "Part 6" },
                    { new Guid("76410231-b1c0-4232-b59f-0260a7c1873e"), "Part 5" },
                    { new Guid("819dd862-ed03-493d-90c9-7cb0b88e52e3"), "Part 4" },
                    { new Guid("889226ff-cd6f-4a3f-80a6-4478815f3c29"), "Part 7" },
                    { new Guid("995680a6-acc5-4089-a90b-6cbfe0bc8429"), "Part 2" },
                    { new Guid("eaf9878b-5b78-481f-9056-448f211cb0ae"), "Part 1" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("5acd151b-83aa-436e-bec7-79e6321b7293"), "Full Test" },
                    { new Guid("a034475f-9b67-40c5-a5d3-9ec0b3a96b6a"), "Mini Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "219d1cd9-c977-4e52-954c-f19bd89dd84b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22023ea6-74ae-4f0f-8694-ef7476ffb0d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a98e1ff-2f3f-4dc1-8983-faeb0d7c6337");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4538cf6-b28c-4382-bde7-586e5b4ac867");

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("18b74324-6ce9-4285-9943-302cf23edbd6"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("64f8b840-9a17-4fef-b940-3fed9e7a5756"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("76410231-b1c0-4232-b59f-0260a7c1873e"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("819dd862-ed03-493d-90c9-7cb0b88e52e3"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("889226ff-cd6f-4a3f-80a6-4478815f3c29"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("995680a6-acc5-4089-a90b-6cbfe0bc8429"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("eaf9878b-5b78-481f-9056-448f211cb0ae"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("5acd151b-83aa-436e-bec7-79e6321b7293"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("a034475f-9b67-40c5-a5d3-9ec0b3a96b6a"));

            migrationBuilder.AlterColumn<string>(
                name: "translation",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "script",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "paragraph",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "audio",
                table: "TestQuestionUnits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03d370ff-a4f1-4dc1-8943-1e7e5f550986", "1", "Admin", "Admin" },
                    { "5a4199fb-2238-42a7-b713-bc96be5b05aa", "2", "Student", "Student" },
                    { "bc8b3d09-e5d8-4bbb-8d68-d624db8f91c8", "4", "Professor", "Professor" },
                    { "eb0d5c9f-e0e6-44d5-b4b0-09e14379c8d5", "3", "VipStudent", "VipStudent" }
                });

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { new Guid("ab205728-050d-4c22-93b6-4171d0dbefe5"), "Part 7" },
                    { new Guid("b0817960-09d4-445d-a9bf-62a5327c584a"), "Part 5" },
                    { new Guid("b5450201-44a4-48b7-9773-49c86ded2335"), "Part 4" },
                    { new Guid("c15ff8d6-3a57-40de-a196-c697d62fd490"), "Part 1" },
                    { new Guid("c2e10783-0588-4c0a-99b0-d698bde0a070"), "Part 3" },
                    { new Guid("ca835428-6ebc-4f65-82f7-d6d17f1954e3"), "Part 2" },
                    { new Guid("dad8b106-b3ff-4b11-8086-c1f05ae5e58d"), "Part 6" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("6816bbf3-5fc2-436c-a66d-38b0527f300e"), "Full Test" },
                    { new Guid("a78210d6-5920-49fe-84d1-467111e86507"), "Mini Test" }
                });
        }
    }
}
