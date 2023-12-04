using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class UpdatePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayVipPackage",
                table: "VipPackages");

            migrationBuilder.DropIndex(
                name: "IX_VipPackages_idPayment",
                table: "VipPackages");

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
                name: "idPayment",
                table: "VipPackages");

            migrationBuilder.AddColumn<Guid>(
                name: "idPackage",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0aa33b6b-4b39-467c-8207-1bb6a7cfd266", "2", "Student", "Student" },
                    { "1a15aede-c9f7-4889-a5e5-6e4b57c4adce", "3", "VipStudent", "VipStudent" },
                    { "24233a26-93ec-4975-8644-ed6b562afaa4", "4", "Professor", "Professor" },
                    { "9a9f1028-5f32-421b-86e8-0a590fb9f3d5", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_idPackage",
                table: "Payments",
                column: "idPackage");

            migrationBuilder.AddForeignKey(
                name: "PaymentOfVipPackage",
                table: "Payments",
                column: "idPackage",
                principalTable: "VipPackages",
                principalColumn: "idPackage",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PaymentOfVipPackage",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_idPackage",
                table: "Payments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0aa33b6b-4b39-467c-8207-1bb6a7cfd266");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a15aede-c9f7-4889-a5e5-6e4b57c4adce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24233a26-93ec-4975-8644-ed6b562afaa4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a9f1028-5f32-421b-86e8-0a590fb9f3d5");

            migrationBuilder.DropColumn(
                name: "idPackage",
                table: "Payments");

            migrationBuilder.AddColumn<Guid>(
                name: "idPayment",
                table: "VipPackages",
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
                name: "IX_VipPackages_idPayment",
                table: "VipPackages",
                column: "idPayment");

            migrationBuilder.AddForeignKey(
                name: "FK_PayVipPackage",
                table: "VipPackages",
                column: "idPayment",
                principalTable: "Payments",
                principalColumn: "idPayment");
        }
    }
}
