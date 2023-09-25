using System;
using Microsoft.EntityFrameworkCore.Migrations;

// #nullable disable

namespace rar.Migrations
{
    /// <inheritdoc />
    public partial class _2ndDbIteration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccidentType",
                columns: table => new
                {
                    AccidentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfAccident = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentType", x => x.AccidentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AreaCode",
                columns: table => new
                {
                    AreaCodeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaCode", x => x.AreaCodeID);
                });

            migrationBuilder.CreateTable(
                name: "Collision",
                columns: table => new
                {
                    CollisionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColiisionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collision", x => x.CollisionID);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictID);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                });

            // migrationBuilder.CreateTable(
            //     name: "User",
            //     columns: table => new
            //     {
            //         Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //         PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //         TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //         LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //         LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //         AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_User", x => x.Id);
            //     });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfWeather = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PoliceStation",
                columns: table => new
                {
                    PoliceStationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceID = table.Column<int>(type: "int", nullable: false),
                    DistrictID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceStation", x => x.PoliceStationID);
                    table.ForeignKey(
                        name: "FK_PoliceStation_District_DistrictID",
                        column: x => x.DistrictID,
                        principalTable: "District",
                        principalColumn: "DistrictID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoliceStation_Province_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            // migrationBuilder.CreateTable(
            //     name: "Account",
            //     columns: table => new
            //     {
            //         AccountID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Cell = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         IdentityDoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         MarriageDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Account", x => x.AccountID);
            //         table.ForeignKey(
            //             name: "FK_Account_User_Id",
            //             column: x => x.Id,
            //             principalTable: "User",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateTable(
                name: "AccidentReport",
                columns: table => new
                {
                    AccidentReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccidentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccidentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccidentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrPeopleKilled = table.Column<int>(type: "int", nullable: false),
                    NrPeopleInjured = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    PoliceStationID = table.Column<int>(type: "int", nullable: false),
                    AccidentTypeID = table.Column<int>(type: "int", nullable: false),
                    AreaCodeID = table.Column<int>(type: "int", nullable: false),
                    WeatherTypeID = table.Column<int>(type: "int", nullable: false),
                    CollisionIDID = table.Column<int>(type: "int", nullable: false),
                    CollisionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccidentReport", x => x.AccidentReportID);
                    table.ForeignKey(
                        name: "FK_AccidentReport_AccidentType_AccidentTypeID",
                        column: x => x.AccidentTypeID,
                        principalTable: "AccidentType",
                        principalColumn: "AccidentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentReport_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentReport_AreaCode_AreaCodeID",
                        column: x => x.AreaCodeID,
                        principalTable: "AreaCode",
                        principalColumn: "AreaCodeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentReport_Collision_CollisionID",
                        column: x => x.CollisionID,
                        principalTable: "Collision",
                        principalColumn: "CollisionID");
                    table.ForeignKey(
                        name: "FK_AccidentReport_PoliceStation_PoliceStationID",
                        column: x => x.PoliceStationID,
                        principalTable: "PoliceStation",
                        principalColumn: "PoliceStationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccidentReport_Weather_WeatherTypeID",
                        column: x => x.WeatherTypeID,
                        principalTable: "Weather",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            // migrationBuilder.CreateTable(
            //     name: "Address",
            //     columns: table => new
            //     {
            //         AddressID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         AccountID = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Address", x => x.AddressID);
            //         table.ForeignKey(
            //             name: "FK_Address_Account_AccountID",
            //             column: x => x.AccountID,
            //             principalTable: "Account",
            //             principalColumn: "AccountID",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReport_AccidentTypeID",
                table: "AccidentReport",
                column: "AccidentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReport_AccountID",
                table: "AccidentReport",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReport_AreaCodeID",
                table: "AccidentReport",
                column: "AreaCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReport_CollisionID",
                table: "AccidentReport",
                column: "CollisionID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReport_PoliceStationID",
                table: "AccidentReport",
                column: "PoliceStationID");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentReport_WeatherTypeID",
                table: "AccidentReport",
                column: "WeatherTypeID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Account_Id",
            //     table: "Account",
            //     column: "Id");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Address_AccountID",
            //     table: "Address",
            //     column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceStation_DistrictID",
                table: "PoliceStation",
                column: "DistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceStation_ProvinceID",
                table: "PoliceStation",
                column: "ProvinceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccidentReport");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AccidentType");

            migrationBuilder.DropTable(
                name: "AreaCode");

            migrationBuilder.DropTable(
                name: "Collision");

            migrationBuilder.DropTable(
                name: "PoliceStation");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
