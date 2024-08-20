using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tafarrod.DAL.Migrations
{
    /// <inheritdoc />
    public partial class M9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                table: "Workers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CV",
                table: "Workers",
                type: "VARBINARY(MAX)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
