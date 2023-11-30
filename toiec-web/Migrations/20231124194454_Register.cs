using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toiec_web.Migrations
{
    public partial class Register : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mobile",
                table: "AspNetUsers",
                newName: "Mobile");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "AspNetUsers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "AspNetUsers",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "dateOfBirth",
                table: "AspNetUsers",
                newName: "DateOfBirth");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Mobile",
                table: "AspNetUsers",
                newName: "mobile");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "AspNetUsers",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "AspNetUsers",
                newName: "fullname");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "AspNetUsers",
                newName: "dateOfBirth");
        }
    }
}
