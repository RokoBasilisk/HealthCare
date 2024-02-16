using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations.EventStoreDb
{
    /// <inheritdoc />
    public partial class CreatedEventStoreTable : Migration
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
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    RoleDescription = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    Version = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventBase",
                columns: table => new
                {
                    AggregateId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageType = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ClientIdId = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: true),
                    Data = table.Column<string>(type: "VARCHAR(MAX)", unicode: false, nullable: true, comment: "JSON serialized event")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventBase", x => x.AggregateId);
                    table.ForeignKey(
                        name: "FK_EventBase_ClientId_ClientIdId",
                        column: x => x.ClientIdId,
                        principalTable: "ClientId",
                        principalColumn: "Id");
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
                        name: "FK_ClientIdRole_Role_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientIdRole_RolesId",
                table: "ClientIdRole",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_EventBase_ClientIdId",
                table: "EventBase",
                column: "ClientIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientIdRole");

            migrationBuilder.DropTable(
                name: "EventBase");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "ClientId");
        }
    }
}
