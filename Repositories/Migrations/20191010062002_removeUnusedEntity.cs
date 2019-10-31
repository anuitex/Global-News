using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class removeUnusedEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscriptionNewsSends");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubscriptionNewsSends",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    NewsId = table.Column<string>(nullable: true),
                    SubscriptionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionNewsSends", x => x.Id);
                });
        }
    }
}
