using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoVideojuegos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacionVideojuegoPlataforma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlataformaVideojuego",
                columns: table => new
                {
                    PlataformasId = table.Column<int>(type: "integer", nullable: false),
                    VideojuegosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlataformaVideojuego", x => new { x.PlataformasId, x.VideojuegosId });
                    table.ForeignKey(
                        name: "FK_PlataformaVideojuego_Plataformas_PlataformasId",
                        column: x => x.PlataformasId,
                        principalTable: "Plataformas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlataformaVideojuego_Videojuegos_VideojuegosId",
                        column: x => x.VideojuegosId,
                        principalTable: "Videojuegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlataformaVideojuego_VideojuegosId",
                table: "PlataformaVideojuego",
                column: "VideojuegosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlataformaVideojuego");
        }
    }
}
