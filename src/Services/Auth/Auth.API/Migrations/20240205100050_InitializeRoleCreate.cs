using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class InitializeRoleCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginId = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleDescription = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientIdRole",
                columns: table => new
                {
                    ClientIdsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdRole", x => new { x.ClientIdsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_ClientIdRole_ClientId_ClientIdsId",
                        column: x => x.ClientIdsId,
                        principalTable: "ClientId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientIdRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdRole_RolesId",
                table: "ClientIdRole",
                column: "RolesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientIdRole");

            migrationBuilder.DropTable(
                name: "ClientId");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
