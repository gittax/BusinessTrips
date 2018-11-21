using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class fix_request : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_ProjectId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_SubprojectId",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ProjectId",
                table: "Request",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_SubprojectId",
                table: "Request",
                column: "SubprojectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Request_ProjectId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_SubprojectId",
                table: "Request");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ProjectId",
                table: "Request",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Request_SubprojectId",
                table: "Request",
                column: "SubprojectId",
                unique: true,
                filter: "[SubprojectId] IS NOT NULL");
        }
    }
}
