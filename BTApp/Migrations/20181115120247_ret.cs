using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class ret : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubprojectId",
                table: "Request",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Request",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Project_ProjectId",
                table: "Request",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Request_Project_ProjectId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Subproject_SubprojectId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_ProjectId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_SubprojectId",
                table: "Request");

            migrationBuilder.AlterColumn<int>(
                name: "SubprojectId",
                table: "Request",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Request",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
