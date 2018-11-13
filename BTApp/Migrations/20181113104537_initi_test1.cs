using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class initi_test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubprojectId",
                table: "Request",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_SubprojectId",
                table: "Request",
                column: "SubprojectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Subproject_SubprojectId",
                table: "Request",
                column: "SubprojectId",
                principalTable: "Subproject",
                principalColumn: "SubprojectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Subproject_SubprojectId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_SubprojectId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "SubprojectId",
                table: "Request");
        }
    }
}
