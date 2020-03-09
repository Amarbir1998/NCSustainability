using Microsoft.EntityFrameworkCore.Migrations;

namespace NCSustainability.Data.NCMigrations
{
    public partial class NameNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "News",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "News");
        }
    }
}
