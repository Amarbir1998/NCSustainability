using Microsoft.EntityFrameworkCore.Migrations;

namespace NC_Sustainability.Data.NCMigrations
{
    public partial class authen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EventDescription",
                schema: "dbo",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EventDescription",
                schema: "dbo",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
