using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE ""ClientPasswords"" ALTER COLUMN ""Password"" TYPE BYTEA USING ""Password""::bytea");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "ClientPasswords",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "ClientPasswords",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "ClientPasswords");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "ClientPasswords",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");
        }
    }
}
