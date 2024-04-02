using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toeic_web.Migrations
{
    public partial class addpronunciation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "wordType",
                table: "Vocabularies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "pronunciation",
                table: "Vocabularies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pronunciation",
                table: "Vocabularies");

            migrationBuilder.AlterColumn<string>(
                name: "wordType",
                table: "Vocabularies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
