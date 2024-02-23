using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class AddClientRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientIdRole_ClientId_ClientIdsId",
                table: "ClientIdRole");

            migrationBuilder.DropTable(
                name: "ClientId");

            migrationBuilder.CreateTable(
                name: "ClientInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsLocked = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientPasswords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPasswords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientIds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: false),
                    ClientInformationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientPasswordId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientIds_ClientInformations_ClientInformationId",
                        column: x => x.ClientInformationId,
                        principalTable: "ClientInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientIds_ClientPasswords_ClientPasswordId",
                        column: x => x.ClientPasswordId,
                        principalTable: "ClientPasswords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientIds_ClientInformationId",
                table: "ClientIds",
                column: "ClientInformationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientIds_ClientPasswordId",
                table: "ClientIds",
                column: "ClientPasswordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientIds_Email",
                table: "ClientIds",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientIdRole_ClientIds_ClientIdsId",
                table: "ClientIdRole",
                column: "ClientIdsId",
                principalTable: "ClientIds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientIdRole_ClientIds_ClientIdsId",
                table: "ClientIdRole");

            migrationBuilder.DropTable(
                name: "ClientIds");

            migrationBuilder.DropTable(
                name: "ClientInformations");

            migrationBuilder.DropTable(
                name: "ClientPasswords");

            migrationBuilder.CreateTable(
                name: "ClientId",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LoginId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientId", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClientIdRole_ClientId_ClientIdsId",
                table: "ClientIdRole",
                column: "ClientIdsId",
                principalTable: "ClientId",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
