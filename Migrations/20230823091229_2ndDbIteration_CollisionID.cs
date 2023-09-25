using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rar.Migrations
{
    /// <inheritdoc />
    public partial class _2ndDbIterationCollisionID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccidentReport_Collision_CollisionID",
                table: "AccidentReport");

            migrationBuilder.DropColumn(
                name: "CollisionIDID",
                table: "AccidentReport");

            migrationBuilder.AlterColumn<int>(
                name: "CollisionID",
                table: "AccidentReport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccidentReport_Collision_CollisionID",
                table: "AccidentReport",
                column: "CollisionID",
                principalTable: "Collision",
                principalColumn: "CollisionID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccidentReport_Collision_CollisionID",
                table: "AccidentReport");

            migrationBuilder.AlterColumn<int>(
                name: "CollisionID",
                table: "AccidentReport",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CollisionIDID",
                table: "AccidentReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AccidentReport_Collision_CollisionID",
                table: "AccidentReport",
                column: "CollisionID",
                principalTable: "Collision",
                principalColumn: "CollisionID");
        }
    }
}
