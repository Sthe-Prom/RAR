﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rar.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductionDB2ConfirmedCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "AccidentReport",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "AccidentReport");
        }
    }
}
