using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditoriaEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CriadoPor",
                table: "Enderecos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AtualizadoPor",
                table: "Enderecos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoPor",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "AtualizadoPor",
                table: "Enderecos");
        }
    }
}
