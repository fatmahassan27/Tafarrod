using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tafarrod.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addOccupation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "OccupationId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Occupations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_OccupationId",
                table: "Workers",
                column: "OccupationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Occupations_OccupationId",
                table: "Workers",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Occupations_OccupationId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Occupations");

            migrationBuilder.DropIndex(
                name: "IX_Workers_OccupationId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "OccupationId",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
