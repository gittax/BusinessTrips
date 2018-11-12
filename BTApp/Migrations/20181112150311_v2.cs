using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeBase_EmployeeBaseId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Request_RequestId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Project_ProjectID",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Subproject_Project_ProjectID",
                table: "Subproject");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Employee_EmployeeId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeBaseId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RequestId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Declarer",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Subproject",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subproject",
                newName: "SubprojectId");

            migrationBuilder.RenameIndex(
                name: "IX_Subproject_ProjectID",
                table: "Subproject",
                newName: "IX_Subproject_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Request",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ProjectID",
                table: "Request",
                newName: "IX_Request_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "Project",
                newName: "ProjectId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Request",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeclarerEmployeeBaseId",
                table: "Request",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeBaseId",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Request_DeclarerEmployeeBaseId",
                table: "Request",
                column: "DeclarerEmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeBaseId",
                table: "Employee",
                column: "EmployeeBaseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeBase_EmployeeBaseId",
                table: "Employee",
                column: "EmployeeBaseId",
                principalTable: "EmployeeBase",
                principalColumn: "EmployeeBaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProjectAssign_Employee_EmployeeID",
                table: "EmployeeProjectAssign",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_EmployeeBase_DeclarerEmployeeBaseId",
                table: "Request",
                column: "DeclarerEmployeeBaseId",
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
                name: "FK_Subproject_Project_ProjectId",
                table: "Subproject",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Employee_EmployeeId",
                table: "Ticket",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeBase_EmployeeBaseId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProjectAssign_Employee_EmployeeID",
                table: "EmployeeProjectAssign");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_EmployeeBase_DeclarerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Project_ProjectId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Subproject_Project_ProjectId",
                table: "Subproject");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Employee_EmployeeId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Request_DeclarerEmployeeBaseId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeBaseId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeclarerEmployeeBaseId",
                table: "Request");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Subproject",
                newName: "ProjectID");

            migrationBuilder.RenameColumn(
                name: "SubprojectId",
                table: "Subproject",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Subproject_ProjectId",
                table: "Subproject",
                newName: "IX_Subproject_ProjectID");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Request",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_Request_ProjectId",
                table: "Request",
                newName: "IX_Request_ProjectID");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Project",
                newName: "ProjectID");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProjectID",
                table: "Request",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Declarer",
                table: "Request",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeBaseId",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeBaseId",
                table: "Employee",
                column: "EmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RequestId",
                table: "Employee",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeBase_EmployeeBaseId",
                table: "Employee",
                column: "EmployeeBaseId",
                principalTable: "EmployeeBase",
                principalColumn: "EmployeeBaseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Request_RequestId",
                table: "Employee",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Project_ProjectID",
                table: "Request",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subproject_Project_ProjectID",
                table: "Subproject",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Employee_EmployeeId",
                table: "Ticket",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
