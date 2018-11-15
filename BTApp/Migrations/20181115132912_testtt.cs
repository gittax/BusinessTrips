using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class testtt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_EmployeeBase_ManagerEmployeeBaseId",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "ManagerEmployeeBaseId",
                table: "Project",
                newName: "ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ManagerEmployeeBaseId",
                table: "Project",
                newName: "IX_Project_ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_EmployeeBase_ManagerId",
                table: "Project",
                column: "ManagerId",
                principalTable: "EmployeeBase",
                principalColumn: "EmployeeBaseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_EmployeeBase_ManagerId",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "ManagerId",
                table: "Project",
                newName: "ManagerEmployeeBaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                newName: "IX_Project_ManagerEmployeeBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_EmployeeBase_ManagerEmployeeBaseId",
                table: "Project",
                column: "ManagerEmployeeBaseId",
                principalTable: "EmployeeBase",
                principalColumn: "EmployeeBaseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
