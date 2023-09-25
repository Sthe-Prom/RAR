using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rar.Data.Migrations
{
    /// <inheritdoc />
    public partial class WID2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccidentReport_Weather_ID",
                table: "AccidentReport");

            migrationBuilder.DropIndex(
                name: "IX_AccidentReport_ID",
                table: "AccidentReport");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "AccidentReport");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Weather",
                newName: "WeatherTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReport_WeatherTypeID",
                table: "AccidentReport",
                column: "WeatherTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccidentReport_Weather_WeatherTypeID",
                table: "AccidentReport",
                column: "WeatherTypeID",
                principalTable: "Weather",
                principalColumn: "WeatherTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccidentReport_Weather_WeatherTypeID",
                table: "AccidentReport");

            migrationBuilder.DropIndex(
                name: "IX_AccidentReport_WeatherTypeID",
                table: "AccidentReport");

            migrationBuilder.RenameColumn(
                name: "WeatherTypeID",
                table: "Weather",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "AccidentReport",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReport_ID",
                table: "AccidentReport",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccidentReport_Weather_ID",
                table: "AccidentReport",
                column: "ID",
                principalTable: "Weather",
                principalColumn: "ID");
        }
    }
}
