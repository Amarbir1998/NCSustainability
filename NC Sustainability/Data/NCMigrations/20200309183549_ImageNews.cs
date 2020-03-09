using Microsoft.EntityFrameworkCore.Migrations;

namespace NCSustainability.Data.NCMigrations
{
    public partial class ImageNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                schema: "dbo",
                table: "News",
                newName: "imageContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageContent",
                schema: "dbo",
                table: "News",
                newName: "image");
        }
    }
}
