using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class ResetPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "107f3858-bdaf-4eb9-b7a5-343d894f28ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19ed64c8-3e7b-4275-921c-14b5dd8c7ff2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb38a2eb-847a-4486-b00e-8b7d57a0f46e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f27f31dc-b397-40f5-985c-c6bd2a181000");

            migrationBuilder.CreateTable(
                name: "ResetPasswords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResetPasswords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29c0e89f-0e7b-44fd-8588-4a8a349e7787", "1", "Admin", "Admin" },
                    { "c079269f-669a-454a-aa4d-79b74ef3aac3", "4", "Professor", "Professor" },
                    { "ccfbd1d4-6b93-46e4-9eae-2c4f4dc29c32", "2", "Student", "Student" },
                    { "fbc62268-a748-4241-8207-37b4a49cda90", "3", "VipStudent", "VipStudent" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResetPasswords");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29c0e89f-0e7b-44fd-8588-4a8a349e7787");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c079269f-669a-454a-aa4d-79b74ef3aac3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccfbd1d4-6b93-46e4-9eae-2c4f4dc29c32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbc62268-a748-4241-8207-37b4a49cda90");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "107f3858-bdaf-4eb9-b7a5-343d894f28ca", "1", "Admin", "Admin" },
                    { "19ed64c8-3e7b-4275-921c-14b5dd8c7ff2", "4", "Professor", "Professor" },
                    { "bb38a2eb-847a-4486-b00e-8b7d57a0f46e", "3", "VipStudent", "VipStudent" },
                    { "f27f31dc-b397-40f5-985c-c6bd2a181000", "2", "Student", "Student" }
                });
        }
    }
}
