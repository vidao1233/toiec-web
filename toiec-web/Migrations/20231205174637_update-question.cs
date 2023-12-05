using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class updatequestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02f93ef0-7d50-40d0-8609-ffaddc813429");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52a4d0a3-ecec-4b23-9146-aa0a2e42c6e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9441e81c-8c35-4506-bc2e-eba2387db2ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4f76cad-da27-4391-980c-9b9261c92746");

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("0e774dec-da5c-4425-8de9-b8aef4e5a8e5"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("28bfe763-f560-490f-987a-0a32e48da769"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("4b4277e1-809d-4039-8815-175e320eeda7"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("5de519a9-86cc-4831-b868-5410d54c3fbd"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("946b5b11-cc4c-4607-b0f5-a553ad473249"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("c5f788cf-030a-400c-9e20-eeb3453ba9d0"));

            migrationBuilder.DeleteData(
                table: "TestParts",
                keyColumn: "partId",
                keyValue: new Guid("ef856329-eeac-43f4-9860-b1faa2c2fe05"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("4705c792-072a-4478-b38b-e8916a827f80"));

            migrationBuilder.DeleteData(
                table: "TestTypes",
                keyColumn: "idTestType",
                keyValue: new Guid("675ca318-7ae8-4a11-ab6d-630f4890056f"));

            migrationBuilder.AddColumn<string>(
                name: "choice_1",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "choice_2",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "choice_3",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "choice_4",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "choice_1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "choice_2",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "choice_3",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "choice_4",
                table: "Questions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02f93ef0-7d50-40d0-8609-ffaddc813429", "3", "VipStudent", "VipStudent" },
                    { "52a4d0a3-ecec-4b23-9146-aa0a2e42c6e8", "4", "Professor", "Professor" },
                    { "9441e81c-8c35-4506-bc2e-eba2387db2ce", "1", "Admin", "Admin" },
                    { "c4f76cad-da27-4391-980c-9b9261c92746", "2", "Student", "Student" }
                });

            migrationBuilder.InsertData(
                table: "TestParts",
                columns: new[] { "partId", "partName" },
                values: new object[,]
                {
                    { new Guid("0e774dec-da5c-4425-8de9-b8aef4e5a8e5"), "Part 3" },
                    { new Guid("28bfe763-f560-490f-987a-0a32e48da769"), "Part 6" },
                    { new Guid("4b4277e1-809d-4039-8815-175e320eeda7"), "Part 7" },
                    { new Guid("5de519a9-86cc-4831-b868-5410d54c3fbd"), "Part 1" },
                    { new Guid("946b5b11-cc4c-4607-b0f5-a553ad473249"), "Part 5" },
                    { new Guid("c5f788cf-030a-400c-9e20-eeb3453ba9d0"), "Part 4" },
                    { new Guid("ef856329-eeac-43f4-9860-b1faa2c2fe05"), "Part 2" }
                });

            migrationBuilder.InsertData(
                table: "TestTypes",
                columns: new[] { "idTestType", "typeName" },
                values: new object[,]
                {
                    { new Guid("4705c792-072a-4478-b38b-e8916a827f80"), "Mini Test" },
                    { new Guid("675ca318-7ae8-4a11-ab6d-630f4890056f"), "Full Test" }
                });
        }
    }
}
