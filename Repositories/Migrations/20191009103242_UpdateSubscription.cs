using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class UpdateSubscription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SubscribeAll",
                table: "Subscriptions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscribeAll",
                table: "Subscriptions");
        }
    }
}
