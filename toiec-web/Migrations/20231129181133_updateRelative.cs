using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class updateRelative : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminOfUser",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorOfUser",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentOfUser",
                table: "Students");

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
                    { "27a38943-e9a3-42ef-8a5f-13ca002c6dcc", "3", "VipStudent", "VipStudent" },
                    { "30743ecc-bd50-4533-861f-0a0d2470da54", "1", "Admin", "Admin" },
                    { "bdb9e61b-00a7-45e4-ba57-c9ade5881eb6", "2", "Student", "Student" },
                    { "c12f603d-3788-4e79-b883-1569ae3d52aa", "4", "Professor", "Professor" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminOfUser",
                table: "Admins",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorOfUser",
                table: "Professors",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOfUser",
                table: "Students",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminOfUser",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorOfUser",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentOfUser",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a38943-e9a3-42ef-8a5f-13ca002c6dcc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30743ecc-bd50-4533-861f-0a0d2470da54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdb9e61b-00a7-45e4-ba57-c9ade5881eb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c12f603d-3788-4e79-b883-1569ae3d52aa");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AdminOfUser",
                table: "Admins",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorOfUser",
                table: "Professors",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentOfUser",
                table: "Students",
                column: "idUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
