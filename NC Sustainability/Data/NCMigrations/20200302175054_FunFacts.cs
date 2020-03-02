using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NCSustainability.Data.NCMigrations
{
    public partial class FunFacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventCategories_EventCategoryID",
                schema: "dbo",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSubscribers_EventCategories_EventCategoryID",
                schema: "dbo",
                table: "EventSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                schema: "dbo",
                table: "EventCategories");

            migrationBuilder.RenameTable(
                name: "EventCategories",
                schema: "dbo",
                newName: "FunFact",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FunFact",
                schema: "dbo",
                table: "FunFact",
                column: "ID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Events_FunFact_EventCategoryID",
                schema: "dbo",
                table: "Events",
                column: "EventCategoryID",
                principalSchema: "dbo",
                principalTable: "FunFact",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSubscribers_FunFact_EventCategoryID",
                schema: "dbo",
                table: "EventSubscribers",
                column: "EventCategoryID",
                principalSchema: "dbo",
                principalTable: "FunFact",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_FunFact_EventCategoryID",
                schema: "dbo",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSubscribers_FunFact_EventCategoryID",
                schema: "dbo",
                table: "EventSubscribers");

            migrationBuilder.DropTable(
                name: "LikedFunfacts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FunFacts",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FunFact",
                schema: "dbo",
                table: "FunFact");

            migrationBuilder.RenameTable(
                name: "FunFact",
                schema: "dbo",
                newName: "EventCategories",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                schema: "dbo",
                table: "EventCategories",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventCategories_EventCategoryID",
                schema: "dbo",
                table: "Events",
                column: "EventCategoryID",
                principalSchema: "dbo",
                principalTable: "EventCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSubscribers_EventCategories_EventCategoryID",
                schema: "dbo",
                table: "EventSubscribers",
                column: "EventCategoryID",
                principalSchema: "dbo",
                principalTable: "EventCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
