using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTApp.Migrations
{
    public partial class InitialCreate : Migration
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
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ManagerEmployeeBaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Project_EmployeeBase_ManagerEmployeeBaseId",
                        column: x => x.ManagerEmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjectAssign",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false),
                    ProjectID = table.Column<int>(nullable: false),
                    EmployeeBaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjectAssign", x => new { x.EmployeeID, x.ProjectID });
                    table.ForeignKey(
                        name: "FK_EmployeeProjectAssign_EmployeeBase_EmployeeBaseId",
                        column: x => x.EmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeProjectAssign_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
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
                    Declarer = table.Column<string>(nullable: true),
                    BusinessTripNumber = table.Column<string>(nullable: true),
                    Budget = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    ManagerEmployeeBaseId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OfficeManagerEmployeeBaseId = table.Column<int>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
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
                        name: "FK_Request_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subproject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProjectID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subproject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subproject_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
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
                    RequestId = table.Column<int>(nullable: true),
                    EmployeeBaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeBase_EmployeeBaseId",
                        column: x => x.EmployeeBaseId,
                        principalTable: "EmployeeBase",
                        principalColumn: "EmployeeBaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Request_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
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
                    EmployeeId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
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
                    EmployeeID = table.Column<int>(nullable: false),
                    RouteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRouteAssign", x => new { x.EmployeeID, x.RouteID });
                    table.ForeignKey(
                        name: "FK_EmployeeRouteAssign_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRouteAssign_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeBaseId",
                table: "Employee",
                column: "EmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RequestId",
                table: "Employee",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjectAssign_EmployeeBaseId",
                table: "EmployeeProjectAssign",
                column: "EmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjectAssign_ProjectID",
                table: "EmployeeProjectAssign",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRouteAssign_RouteID",
                table: "EmployeeRouteAssign",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerEmployeeBaseId",
                table: "Project",
                column: "ManagerEmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ManagerEmployeeBaseId",
                table: "Request",
                column: "ManagerEmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_OfficeManagerEmployeeBaseId",
                table: "Request",
                column: "OfficeManagerEmployeeBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ProjectID",
                table: "Request",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_RequestId",
                table: "Route",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Subproject_ProjectID",
                table: "Subproject",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EmployeeId",
                table: "Ticket",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RequestId",
                table: "Ticket",
                column: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjectAssign");

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
