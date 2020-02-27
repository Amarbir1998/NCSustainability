using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NCSustainability.Data.NCMigrations
{
    public partial class LikeFunFacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FunFacts",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FunFactDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunFacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LikedFunfacts",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    FunfactID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedFunfacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LikedFunfacts_FunFacts_FunfactID",
                        column: x => x.FunfactID,
                        principalSchema: "dbo",
                        principalTable: "FunFacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedFunfacts_Email",
                schema: "dbo",
                table: "LikedFunfacts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LikedFunfacts_FunfactID",
                schema: "dbo",
                table: "LikedFunfacts",
                column: "FunfactID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedFunfacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FunFacts",
                schema: "dbo");
        }
    }
}
