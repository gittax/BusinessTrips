using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class db_wo_types_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_EmployeeBase_DeclarerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_EmployeeBase_ManagerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_EmployeeBase_OfficeManagerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Project_ProjectId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Subproject_SubprojectId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_DeclarerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_ManagerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_OfficeManagerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_ProjectId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_SubprojectId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "DeclarerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "ManagerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "OfficeManagerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "SubprojectId",
                table: "Request");

            migrationBuilder.AddColumn<int>(
                name: "DeclarerId",
                table: "Request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeManagerId",
                table: "Request",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Subproject",
                table: "Request",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeclarerId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "OfficeManagerId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Subproject",
                table: "Request");

            migrationBuilder.AddColumn<int>(
                name: "DeclarerEmployeeBaseId",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerEmployeeBaseId",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeManagerEmployeeBaseId",
                table: "Request",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubprojectId",
                table: "Request",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_DeclarerEmployeeBaseId",
                table: "Request",
                column: "DeclarerEmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ManagerEmployeeBaseId",
                table: "Request",
                column: "ManagerEmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_OfficeManagerEmployeeBaseId",
                table: "Request",
                column: "OfficeManagerEmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ProjectId",
                table: "Request",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_SubprojectId",
                table: "Request",
                column: "SubprojectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_EmployeeBase_DeclarerEmployeeBaseId",
                table: "Request",
                column: "DeclarerEmployeeBaseId",
                principalTable: "EmployeeBase",
                principalColumn: "EmployeeBaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_EmployeeBase_ManagerEmployeeBaseId",
                table: "Request",
                column: "ManagerEmployeeBaseId",
                principalTable: "EmployeeBase",
                principalColumn: "EmployeeBaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_EmployeeBase_OfficeManagerEmployeeBaseId",
                table: "Request",
                column: "OfficeManagerEmployeeBaseId",
                principalTable: "EmployeeBase",
                principalColumn: "EmployeeBaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Project_ProjectId",
                table: "Request",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Subproject_SubprojectId",
                table: "Request",
                column: "SubprojectId",
                principalTable: "Subproject",
                principalColumn: "SubprojectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
