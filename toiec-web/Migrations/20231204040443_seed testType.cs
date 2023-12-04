using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class seedtestType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b3496d4-1bbf-47e7-8681-828cf793e293");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa5f7353-b0d1-4d62-9e50-840975d64f4b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba5f7d62-a7f2-401f-89bf-c15af105a7f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8a9135d-a2c8-4467-8a51-ad73e97de8c6");

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("1bb1f780-4ebb-4bd2-b77d-a8bd08a6b814"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("54e3578d-dc58-4cb1-9fc8-b63d4c46799a"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("582fd57f-bc05-42e8-8671-decf487bb623"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("5e84d0ce-ee2e-4e62-8bd0-3cafa1b48979"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("7fd64f89-fb10-46e3-b2fc-95447bc7752e"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("da35c817-8474-42da-9a7d-d3fb607e1e57"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("db6a976c-276a-47ac-a013-52ce7bcf9c14"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b3496d4-1bbf-47e7-8681-828cf793e293", "1", "Admin", "Admin" },
                    { "aa5f7353-b0d1-4d62-9e50-840975d64f4b", "3", "VipStudent", "VipStudent" },
                    { "ba5f7d62-a7f2-401f-89bf-c15af105a7f6", "4", "Professor", "Professor" },
                    { "c8a9135d-a2c8-4467-8a51-ad73e97de8c6", "2", "Student", "Student" }
                });

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { new Guid("1bb1f780-4ebb-4bd2-b77d-a8bd08a6b814"), "Part 7" },
                    { new Guid("54e3578d-dc58-4cb1-9fc8-b63d4c46799a"), "Part 6" },
                    { new Guid("582fd57f-bc05-42e8-8671-decf487bb623"), "Part 2" },
                    { new Guid("5e84d0ce-ee2e-4e62-8bd0-3cafa1b48979"), "Part 4" },
                    { new Guid("7fd64f89-fb10-46e3-b2fc-95447bc7752e"), "Part 5" },
                    { new Guid("da35c817-8474-42da-9a7d-d3fb607e1e57"), "Part 3" },
                    { new Guid("db6a976c-276a-47ac-a013-52ce7bcf9c14"), "Part 1" }
                });
        }
    }
}
