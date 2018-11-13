using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeBase",
                columns: table => new
                {
                    EmployeeBaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBase", x => x.EmployeeBaseId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DocType = table.Column<int>(nullable: false),
                    DocNumber = table.Column<string>(nullable: true),
                    ValidThrough = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BirthPlace = table.Column<string>(nullable: true),
                    EmployeeBaseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeBase_EmployeeBaseId",
                        column: x => x.EmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ManagerEmployeeBaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_EmployeeBase_ManagerEmployeeBaseId",
                        column: x => x.ManagerEmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBaseProjectAssign",
                columns: table => new
                {
                    EmployeeBaseId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBaseProjectAssign", x => new { x.EmployeeBaseId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeeBaseProjectAssign_EmployeeBase_EmployeeBaseId",
                        column: x => x.EmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeBaseProjectAssign_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeBaseProjectAssign_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestNumber = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BusinessTripNumber = table.Column<string>(nullable: true),
                    Budget = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DeclarerEmployeeBaseId = table.Column<int>(nullable: true),
                    ManagerEmployeeBaseId = table.Column<int>(nullable: true),
                    OfficeManagerEmployeeBaseId = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Request_EmployeeBase_DeclarerEmployeeBaseId",
                        column: x => x.DeclarerEmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_EmployeeBase_ManagerEmployeeBaseId",
                        column: x => x.ManagerEmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_EmployeeBase_OfficeManagerEmployeeBaseId",
                        column: x => x.OfficeManagerEmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subproject",
                columns: table => new
                {
                    SubprojectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subproject", x => x.SubprojectId);
                    table.ForeignKey(
                        name: "FK_Subproject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    RouteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteType = table.Column<int>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    TicketType = table.Column<int>(nullable: false),
                    DepartureCity = table.Column<string>(nullable: true),
                    ArrivalCity = table.Column<string>(nullable: true),
                    FlightNumber = table.Column<string>(nullable: true),
                    ClassType = table.Column<int>(nullable: false),
                    Budget = table.Column<double>(nullable: false),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_Route_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cost = table.Column<double>(nullable: false),
                    RouteType = table.Column<int>(nullable: false),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRouteAssign",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false),
                    RouteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRouteAssign", x => new { x.EmployeeId, x.RouteId });
                    table.ForeignKey(
                        name: "FK_EmployeeRouteAssign_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRouteAssign_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeBaseId",
                table: "Employee",
                column: "EmployeeBaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBaseProjectAssign_EmployeeId",
                table: "EmployeeBaseProjectAssign",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBaseProjectAssign_ProjectId",
                table: "EmployeeBaseProjectAssign",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRouteAssign_RouteId",
                table: "EmployeeRouteAssign",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerEmployeeBaseId",
                table: "Project",
                column: "ManagerEmployeeBaseId");

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
                name: "IX_Route_RequestId",
                table: "Route",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Subproject_ProjectId",
                table: "Subproject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RequestId",
                table: "Ticket",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeBaseProjectAssign");

            migrationBuilder.DropTable(
                name: "EmployeeRouteAssign");

            migrationBuilder.DropTable(
                name: "Subproject");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "EmployeeBase");
        }
    }
}
