using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoVideojuegos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarVideojuego : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Multijugador",
                table: "Videojuegos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Videojuegos",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Multijugador",
                table: "Videojuegos");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Videojuegos");
        }
    }
}
