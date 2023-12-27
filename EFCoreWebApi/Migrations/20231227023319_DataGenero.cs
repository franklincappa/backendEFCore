using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class DataGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genero",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 5, "Ciencia Ficción" },
                    { 6, "Animación" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genero",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
