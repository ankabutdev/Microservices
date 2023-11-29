using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Apartment.API.Migrations
{
    /// <inheritdoc />
    public partial class initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.RenameTable(
                name: "Apartments",
                newName: "ApartmentModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentModel",
                table: "ApartmentModel",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentModel",
                table: "ApartmentModel");

            migrationBuilder.RenameTable(
                name: "ApartmentModel",
                newName: "Apartments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "Id");
        }
    }
}
