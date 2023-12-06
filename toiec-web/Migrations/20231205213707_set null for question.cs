using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class setnullforquestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("63152fce-ef3d-4873-91ea-06e799fba05a"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("a9986cb0-3e04-498c-b85f-d647dcad7760"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("aece01aa-4fe8-47a9-ba69-5a20ab0a67d6"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("bf3272a0-81d7-451c-a4ad-4803d2f8ff7f"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("c40fdf03-f171-472f-aecf-43141d5e25ee"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("f1a0073a-a0d8-4053-9176-3cdf7f54c3da"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("f1d383cf-4023-41db-9bee-20832cf31fd5"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("86373e27-a594-4075-b2fa-340b5055adb2"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("fe3844c1-6886-43ea-bd20-b35bbf38e1c0"));

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { new Guid("21481619-81e6-4b63-ac64-2459a51a65d9"), "Part 3" },
                    { new Guid("38fbc195-cdba-411a-b232-abd5e27adaad"), "Part 2" },
                    { new Guid("a1e3cda7-22bd-4ec9-875c-6a004ddec4b3"), "Part 4" },
                    { new Guid("c0c08fa9-8ad7-43a7-8bc2-878dc8b1da10"), "Part 6" },
                    { new Guid("d79c8eb4-6882-429d-8489-35447604cd5c"), "Part 5" },
                    { new Guid("dd3ee4d3-8211-4da8-ad09-2d13a1cc4319"), "Part 7" },
                    { new Guid("f60cb081-7d58-4596-a453-6dc907341fb4"), "Part 1" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("47d0a6a5-0f39-4c1d-84bc-ed10fbc6e4b7"), "Full Test" },
                    { new Guid("db936649-0502-4505-be4c-2ed2cae1a268"), "Mini Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("21481619-81e6-4b63-ac64-2459a51a65d9"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("38fbc195-cdba-411a-b232-abd5e27adaad"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("a1e3cda7-22bd-4ec9-875c-6a004ddec4b3"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("c0c08fa9-8ad7-43a7-8bc2-878dc8b1da10"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("d79c8eb4-6882-429d-8489-35447604cd5c"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("dd3ee4d3-8211-4da8-ad09-2d13a1cc4319"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("f60cb081-7d58-4596-a453-6dc907341fb4"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("47d0a6a5-0f39-4c1d-84bc-ed10fbc6e4b7"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("db936649-0502-4505-be4c-2ed2cae1a268"));

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { new Guid("63152fce-ef3d-4873-91ea-06e799fba05a"), "Part 5" },
                    { new Guid("a9986cb0-3e04-498c-b85f-d647dcad7760"), "Part 2" },
                    { new Guid("aece01aa-4fe8-47a9-ba69-5a20ab0a67d6"), "Part 1" },
                    { new Guid("bf3272a0-81d7-451c-a4ad-4803d2f8ff7f"), "Part 6" },
                    { new Guid("c40fdf03-f171-472f-aecf-43141d5e25ee"), "Part 3" },
                    { new Guid("f1a0073a-a0d8-4053-9176-3cdf7f54c3da"), "Part 4" },
                    { new Guid("f1d383cf-4023-41db-9bee-20832cf31fd5"), "Part 7" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("86373e27-a594-4075-b2fa-340b5055adb2"), "Mini Test" },
                    { new Guid("fe3844c1-6886-43ea-bd20-b35bbf38e1c0"), "Full Test" }
                });
        }
    }
}
