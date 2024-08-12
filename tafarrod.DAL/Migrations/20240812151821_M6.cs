using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tafarrod.DAL.Migrations
{
    /// <inheritdoc />
    public partial class M6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecruitmentPrice",
                table: "Workers");

            migrationBuilder.AddColumn<long>(
                name: "RecruitmentPrice",
                table: "Nationalities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecruitmentPrice",
                table: "Nationalities");

            migrationBuilder.AddColumn<long>(
                name: "RecruitmentPrice",
                table: "Workers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
