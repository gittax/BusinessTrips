using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subproject",
                table: "Request",
                newName: "SubprojectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubprojectId",
                table: "Request",
                newName: "Subproject");
        }
    }
}
