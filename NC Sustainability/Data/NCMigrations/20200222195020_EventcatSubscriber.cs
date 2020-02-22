using Microsoft.EntityFrameworkCore.Migrations;

namespace NCSustainability.Data.NCMigrations
{
    public partial class EventcatSubscriber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventSubscribers",
                schema: "dbo",
                columns: table => new
                {
                    EventCategoryID = table.Column<int>(nullable: false),
                    SubscriberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSubscribers", x => new { x.EventCategoryID, x.SubscriberID });
                    table.ForeignKey(
                        name: "FK_EventSubscribers_EventCategories_EventCategoryID",
                        column: x => x.EventCategoryID,
                        principalSchema: "dbo",
                        principalTable: "EventCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventSubscribers_subscribers_SubscriberID",
                        column: x => x.SubscriberID,
                        principalSchema: "dbo",
                        principalTable: "subscribers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSubscribers_SubscriberID",
                schema: "dbo",
                table: "EventSubscribers",
                column: "SubscriberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventSubscribers",
                schema: "dbo");
        }
    }
}
