using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MadeSomeChangesInCarTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarDetails_CarDetailsId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarDetailsId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarDetailsId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "BigImageUrl",
                table: "Cars",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarKM",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Fuel",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "LuggageCount",
                table: "Cars",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "SeatCount",
                table: "Cars",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "Transmission",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigImageUrl",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarKM",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Fuel",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "LuggageCount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SeatCount",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarDetailsId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BigImageUrl = table.Column<string>(type: "varchar(500)", nullable: true),
                    CarKM = table.Column<int>(type: "int", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LuggageCount = table.Column<byte>(type: "tinyint", nullable: false),
                    SeatCount = table.Column<byte>(type: "tinyint", nullable: false),
                    Transmission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarDetailsId",
                table: "Cars",
                column: "CarDetailsId",
                unique: true,
                filter: "[CarDetailsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarDetails_CarDetailsId",
                table: "Cars",
                column: "CarDetailsId",
                principalTable: "CarDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
