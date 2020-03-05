using Microsoft.EntityFrameworkCore.Migrations;

namespace NCSustainability.Data.NCMigrations
{
    public partial class PhoneSubs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                schema: "dbo",
                table: "Promotions",
                newName: "imageContent");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "dbo",
                table: "subscribers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "dbo",
                table: "subscribers");

            migrationBuilder.RenameColumn(
                name: "imageContent",
                schema: "dbo",
                table: "Promotions",
                newName: "image");
        }
    }
}
