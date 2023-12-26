using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class RelacionPeliculaComentario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeliculaId",
                table: "Comentario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_PeliculaId",
                table: "Comentario",
                column: "PeliculaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Pelicula_PeliculaId",
                table: "Comentario",
                column: "PeliculaId",
                principalTable: "Pelicula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Pelicula_PeliculaId",
                table: "Comentario");

            migrationBuilder.DropIndex(
                name: "IX_Comentario_PeliculaId",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "PeliculaId",
                table: "Comentario");
        }
    }
}
