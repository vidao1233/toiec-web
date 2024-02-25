using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toeic_web.Migrations
{
    public partial class changehost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1257b8ad-564a-456f-81a1-d38f180ddd63");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35564c0c-f6fc-4ce5-ad98-f3c362e90ed1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8111cfd6-214a-4694-a13c-c6ec3d7f56b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9faf18a9-5a41-4b13-9db3-63246839aea9");

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("6bbfca05-e7e7-4241-af3e-20c2260b2e17"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("798dcdaa-d4f7-4472-bc8c-fb1999858614"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("d3c3dee6-b419-418a-adf1-9341d20d6478"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("da942924-1998-403e-b8c1-233cdfc10ee4"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("e8d6587e-5ab0-4b96-a990-020c67bf5710"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("f7107858-6e8b-4ec3-b94d-245045aafb3d"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("fbc48290-ebf2-43f9-a8c5-c323ececd27d"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("2e64e168-ef90-45fa-9df3-281c51f3ddb1"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("f8abe6e4-abc9-45f2-b550-73fd2c44c82b"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1257b8ad-564a-456f-81a1-d38f180ddd63", "2", "Student", "Student" },
                    { "35564c0c-f6fc-4ce5-ad98-f3c362e90ed1", "3", "VipStudent", "VipStudent" },
                    { "8111cfd6-214a-4694-a13c-c6ec3d7f56b2", "1", "Admin", "Admin" },
                    { "9faf18a9-5a41-4b13-9db3-63246839aea9", "4", "Professor", "Professor" }
                });

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { new Guid("6bbfca05-e7e7-4241-af3e-20c2260b2e17"), "Part 4" },
                    { new Guid("798dcdaa-d4f7-4472-bc8c-fb1999858614"), "Part 3" },
                    { new Guid("d3c3dee6-b419-418a-adf1-9341d20d6478"), "Part 1" },
                    { new Guid("da942924-1998-403e-b8c1-233cdfc10ee4"), "Part 2" },
                    { new Guid("e8d6587e-5ab0-4b96-a990-020c67bf5710"), "Part 5" },
                    { new Guid("f7107858-6e8b-4ec3-b94d-245045aafb3d"), "Part 6" },
                    { new Guid("fbc48290-ebf2-43f9-a8c5-c323ececd27d"), "Part 7" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("2e64e168-ef90-45fa-9df3-281c51f3ddb1"), "Full Test" },
                    { new Guid("f8abe6e4-abc9-45f2-b550-73fd2c44c82b"), "Mini Test" }
                });
        }
    }
}
