using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class setidrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17ce9d1c-14cf-4c8a-80dc-b71f5946aff8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30e5c402-989b-434a-82a8-8f12a2826ad5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "682d2a5b-c304-4b21-b0ce-92397073b52e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaed06c9-d8a6-4c85-b8b5-7ac9babe7c3e");

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("023cf62c-f12a-45c1-9f2c-7c3ce6b21a70"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("3be148f4-62d8-4b88-b6df-230f6598ee79"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("93689b6d-d408-4289-bfdb-1e3559c99734"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("cd3b856d-a15d-4c11-a594-70f1559ebb82"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("d081b26c-e674-4c8f-b21b-7f39ab4f8064"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("e8cd92b9-ef77-4b64-96b9-eb138fdd31ed"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("ed748fc1-a425-4fdd-9912-ba805a685260"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("43df5b91-ad0c-4eac-ad75-983e86d48f17"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("edaa579e-e5cc-477b-8c1c-180a30d381b3"));

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
                    { new Guid("059864c1-d15e-4e28-8677-92768b7cb8a3"), "Part 3" },
                    { new Guid("28abc4d9-95af-42c0-b6ca-2e9c9a6052b5"), "Part 7" },
                    { new Guid("2c8617de-6136-434a-92f3-a8756d560a83"), "Part 6" },
                    { new Guid("62660a93-e242-4eaa-b7d6-8f0e52bc6ab6"), "Part 1" },
                    { new Guid("a1279824-fa92-4443-b12b-e69bd83cb619"), "Part 4" },
                    { new Guid("d8c25126-fb55-4a15-aed0-068be0b2a47c"), "Part 5" },
                    { new Guid("fb189b26-5b8d-402e-bb40-ce3822deddec"), "Part 2" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("c6db50f9-f5e3-4d1f-b340-732a182b4a13"), "Full Test" },
                    { new Guid("f16cee9b-9f15-4935-ae19-3c76da09b28a"), "Mini Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("059864c1-d15e-4e28-8677-92768b7cb8a3"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("28abc4d9-95af-42c0-b6ca-2e9c9a6052b5"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("2c8617de-6136-434a-92f3-a8756d560a83"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("62660a93-e242-4eaa-b7d6-8f0e52bc6ab6"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("a1279824-fa92-4443-b12b-e69bd83cb619"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("d8c25126-fb55-4a15-aed0-068be0b2a47c"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("fb189b26-5b8d-402e-bb40-ce3822deddec"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("c6db50f9-f5e3-4d1f-b340-732a182b4a13"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("f16cee9b-9f15-4935-ae19-3c76da09b28a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17ce9d1c-14cf-4c8a-80dc-b71f5946aff8", "1", "Admin", "Admin" },
                    { "30e5c402-989b-434a-82a8-8f12a2826ad5", "2", "Student", "Student" },
                    { "682d2a5b-c304-4b21-b0ce-92397073b52e", "3", "VipStudent", "VipStudent" },
                    { "eaed06c9-d8a6-4c85-b8b5-7ac9babe7c3e", "4", "Professor", "Professor" }
                });

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { new Guid("023cf62c-f12a-45c1-9f2c-7c3ce6b21a70"), "Part 2" },
                    { new Guid("3be148f4-62d8-4b88-b6df-230f6598ee79"), "Part 1" },
                    { new Guid("93689b6d-d408-4289-bfdb-1e3559c99734"), "Part 7" },
                    { new Guid("cd3b856d-a15d-4c11-a594-70f1559ebb82"), "Part 5" },
                    { new Guid("d081b26c-e674-4c8f-b21b-7f39ab4f8064"), "Part 6" },
                    { new Guid("e8cd92b9-ef77-4b64-96b9-eb138fdd31ed"), "Part 4" },
                    { new Guid("ed748fc1-a425-4fdd-9912-ba805a685260"), "Part 3" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("43df5b91-ad0c-4eac-ad75-983e86d48f17"), "Mini Test" },
                    { new Guid("edaa579e-e5cc-477b-8c1c-180a30d381b3"), "Full Test" }
                });
        }
    }
}
