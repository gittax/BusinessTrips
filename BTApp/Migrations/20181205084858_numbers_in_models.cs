using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class numbers_in_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_LookUpClass_ClassTypeValue",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_LookUpClass_RouteTypeValue",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_LookUpClass_TicketTypeValue",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_LookUpClass_RouteTypeValue",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "LookUpClass");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_RouteTypeValue",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Route_ClassTypeValue",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_RouteTypeValue",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_TicketTypeValue",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "RouteTypeValue",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ClassTypeValue",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "RouteTypeValue",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "TicketTypeValue",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "RouteType",
                table: "Ticket",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassType",
                table: "Route",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RouteType",
                table: "Route",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketType",
                table: "Route",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteType",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ClassType",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "RouteType",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "RouteTypeValue",
                table: "Ticket",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassTypeValue",
                table: "Route",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RouteTypeValue",
                table: "Route",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketTypeValue",
                table: "Route",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LookUpClass",
                columns: table => new
                {
                    Value = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpClass", x => x.Value);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RouteTypeValue",
                table: "Ticket",
                column: "RouteTypeValue");

            migrationBuilder.CreateIndex(
                name: "IX_Route_ClassTypeValue",
                table: "Route",
                column: "ClassTypeValue");

            migrationBuilder.CreateIndex(
                name: "IX_Route_RouteTypeValue",
                table: "Route",
                column: "RouteTypeValue");

            migrationBuilder.CreateIndex(
                name: "IX_Route_TicketTypeValue",
                table: "Route",
                column: "TicketTypeValue");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_LookUpClass_ClassTypeValue",
                table: "Route",
                column: "ClassTypeValue",
                principalTable: "LookUpClass",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_LookUpClass_RouteTypeValue",
                table: "Route",
                column: "RouteTypeValue",
                principalTable: "LookUpClass",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_LookUpClass_TicketTypeValue",
                table: "Route",
                column: "TicketTypeValue",
                principalTable: "LookUpClass",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_LookUpClass_RouteTypeValue",
                table: "Ticket",
                column: "RouteTypeValue",
                principalTable: "LookUpClass",
                principalColumn: "Value",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
