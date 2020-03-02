using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NCSustainability.Data.NCMigrations
{
    public partial class updt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_FunFact_EventCategoryID",
                schema: "dbo",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSubscribers_FunFact_EventCategoryID",
                schema: "dbo",
                table: "EventSubscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FunFact",
                schema: "dbo",
                table: "FunFact");

            migrationBuilder.RenameTable(
                name: "FunFact",
                schema: "dbo",
                newName: "EventCategory",
                newSchema: "dbo");

            migrationBuilder.AddColumn<byte[]>(
                name: "imageContent",
                schema: "dbo",
                table: "FunFacts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageFileName",
                schema: "dbo",
                table: "FunFacts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageMimeType",
                schema: "dbo",
                table: "FunFacts",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategory",
                schema: "dbo",
                table: "EventCategory",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "News",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    image = table.Column<byte[]>(nullable: true),
                    imageMimeType = table.Column<string>(maxLength: 256, nullable: true),
                    imageFileName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Pdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    image = table.Column<byte[]>(nullable: true),
                    imageMimeType = table.Column<string>(maxLength: 256, nullable: true),
                    imageFileName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(nullable: false),
                    SPdate = table.Column<DateTime>(nullable: false),
                    EPdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventCategory_EventCategoryID",
                schema: "dbo",
                table: "Events",
                column: "EventCategoryID",
                principalSchema: "dbo",
                principalTable: "EventCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSubscribers_EventCategory_EventCategoryID",
                schema: "dbo",
                table: "EventSubscribers",
                column: "EventCategoryID",
                principalSchema: "dbo",
                principalTable: "EventCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventCategory_EventCategoryID",
                schema: "dbo",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSubscribers_EventCategory_EventCategoryID",
                schema: "dbo",
                table: "EventSubscribers");

            migrationBuilder.DropTable(
                name: "News",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Promotions",
                schema: "dbo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategory",
                schema: "dbo",
                table: "EventCategory");

            migrationBuilder.DropColumn(
                name: "imageContent",
                schema: "dbo",
                table: "FunFacts");

            migrationBuilder.DropColumn(
                name: "imageFileName",
                schema: "dbo",
                table: "FunFacts");

            migrationBuilder.DropColumn(
                name: "imageMimeType",
                schema: "dbo",
                table: "FunFacts");

            migrationBuilder.RenameTable(
                name: "EventCategory",
                schema: "dbo",
                newName: "FunFact",
                newSchema: "dbo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FunFact",
                schema: "dbo",
                table: "FunFact",
                column: "ID");

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
    }
}
