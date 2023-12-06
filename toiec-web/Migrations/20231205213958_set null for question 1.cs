using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class setnullforquestion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("05964104-9e0f-48cf-b7ac-0868b8522269"), "Part 2" },
                    { new Guid("06e8a549-7718-4bb0-9c15-224525d10b0f"), "Part 1" },
                    { new Guid("4985a804-99e7-44bf-bec7-a2f0dff6a9da"), "Part 3" },
                    { new Guid("8e459976-3213-47b0-b695-2f8846b61f8b"), "Part 4" },
                    { new Guid("9766f92b-5c9e-4723-8191-bb43846501d6"), "Part 5" },
                    { new Guid("9ca38118-de2d-4567-aa37-e2c9ad934759"), "Part 6" },
                    { new Guid("e8b85f16-f021-4611-90d9-9613c85589e8"), "Part 7" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("177146a9-5270-4092-a8f3-b385f480b9d8"), "Mini Test" },
                    { new Guid("6a389eb7-551c-402f-a909-974a594892a2"), "Full Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("05964104-9e0f-48cf-b7ac-0868b8522269"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("06e8a549-7718-4bb0-9c15-224525d10b0f"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("4985a804-99e7-44bf-bec7-a2f0dff6a9da"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("8e459976-3213-47b0-b695-2f8846b61f8b"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("9766f92b-5c9e-4723-8191-bb43846501d6"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("9ca38118-de2d-4567-aa37-e2c9ad934759"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("e8b85f16-f021-4611-90d9-9613c85589e8"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("177146a9-5270-4092-a8f3-b385f480b9d8"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("6a389eb7-551c-402f-a909-974a594892a2"));

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
    }
}
