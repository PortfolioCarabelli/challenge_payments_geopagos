using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    client_type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuthorizationRequests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    authorization_type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    status = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    request_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK__Authoriza__clien__1BC821DD",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ApprovedAuthorizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    request_id = table.Column<int>(type: "int", nullable: false),
                    approval_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedAuthorizations", x => x.id);
                    table.ForeignKey(
                        name: "FK__ApprovedA__clien__208CD6FA",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__ApprovedA__reque__1F98B2C1",
                        column: x => x.request_id,
                        principalTable: "AuthorizationRequests",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedAuthorizations_client_id",
                table: "ApprovedAuthorizations",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedAuthorizations_request_id",
                table: "ApprovedAuthorizations",
                column: "request_id");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorizationRequests_client_id",
                table: "AuthorizationRequests",
                column: "client_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovedAuthorizations");

            migrationBuilder.DropTable(
                name: "AuthorizationRequests");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
