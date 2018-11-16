using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class employee_requestId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Employee",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RequestId",
                table: "Employee",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Request_RequestId",
                table: "Employee",
                column: "RequestId",
                principalTable: "Request",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Request_RequestId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RequestId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Employee");
        }
    }
}
