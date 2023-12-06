using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class updaterecordtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "score",
                table: "TestRecords");

            migrationBuilder.AddColumn<int>(
                name: "correctAns",
                table: "TestRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "listenCorrect",
                table: "TestRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "listenScore",
                table: "TestRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "readScore",
                table: "TestRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "readingCorrect",
                table: "TestRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalScore",
                table: "TestRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "wrongAns",
                table: "TestRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "correctAns",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "listenCorrect",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "listenScore",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "readScore",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "readingCorrect",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "totalScore",
                table: "TestRecords");

            migrationBuilder.DropColumn(
                name: "wrongAns",
                table: "TestRecords");

            migrationBuilder.AddColumn<double>(
                name: "score",
                table: "TestRecords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
    }
}
