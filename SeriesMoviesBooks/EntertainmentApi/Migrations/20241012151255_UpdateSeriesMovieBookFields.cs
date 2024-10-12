using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntertainmentApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeriesMovieBookFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lenguaje",
                table: "SeriesMovieBooks",
                newName: "Pais");

            migrationBuilder.RenameColumn(
                name: "Ciudad",
                table: "SeriesMovieBooks",
                newName: "Idioma");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "SeriesMovieBooks",
                newName: "Lenguaje");

            migrationBuilder.RenameColumn(
                name: "Idioma",
                table: "SeriesMovieBooks",
                newName: "Ciudad");
        }
    }
}
