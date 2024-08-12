using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tafarrod.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addNamtionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_NationalityId",
                table: "Workers",
                column: "NationalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Nationalities_NationalityId",
                table: "Workers",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Nationalities_NationalityId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropIndex(
                name: "IX_Workers_NationalityId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
