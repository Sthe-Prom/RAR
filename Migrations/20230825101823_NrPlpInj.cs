using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rar.Migrations
{
    /// <inheritdoc />
    public partial class NrPlpInj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NrPeopleInjured",
                table: "AccidentReport",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NrPeopleInjured",
                table: "AccidentReport",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
