using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreWebApi.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "FechaNacimiento", "Fortuna", "Nombre" },
                values: new object[,]
                {
                    { 2, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, "Samuel L Jackson" },
                    { 3, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000m, "Robert Downey Jr" }
                });

            migrationBuilder.InsertData(
                table: "Pelicula",
                columns: new[] { "Id", "EnCines", "FechaEstreno", "Titulo" },
                values: new object[,]
                {
                    { 2, false, new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers EndGame" },
                    { 3, false, new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man No Way Home" },
                    { 4, false, new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: Across the spider-Verse (Part One)" }
                });

            migrationBuilder.InsertData(
                table: "Comentario",
                columns: new[] { "Id", "Contenido", "PeliculaId", "Recomendar" },
                values: new object[,]
                {
                    { 2, "Muy Buena!!", 2, true },
                    { 3, "Dura Dura", 2, true },
                    { 4, "no debieron hacer eso ...", 3, false },
                    { 5, "locaciones excelentes", 4, true }
                });

            migrationBuilder.InsertData(
                table: "GeneroPelicula",
                columns: new[] { "GenerosId", "PeliculasId" },
                values: new object[,]
                {
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 4 }
                });

            migrationBuilder.InsertData(
                table: "PeliculasActores",
                columns: new[] { "ActorId", "PeliculaId", "Orden", "Personaje" },
                values: new object[,]
                {
                    { 2, 2, 2, "Nick Fury" },
                    { 2, 3, 1, "Nick Fury" },
                    { 3, 4, 1, "Iron Man" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comentario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comentario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comentario",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comentario",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosId", "PeliculasId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosId", "PeliculasId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosId", "PeliculasId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pelicula",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pelicula",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pelicula",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
