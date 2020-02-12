using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NCSustainability.Data.NCMigrations
{
    public partial class Pictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "imageContent",
                schema: "dbo",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageFileName",
                schema: "dbo",
                table: "Events",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageMimeType",
                schema: "dbo",
                table: "Events",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageContent",
                schema: "dbo",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "imageFileName",
                schema: "dbo",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "imageMimeType",
                schema: "dbo",
                table: "Events");
        }
    }
}
