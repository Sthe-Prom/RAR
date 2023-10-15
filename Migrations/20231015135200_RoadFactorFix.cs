using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rar.Migrations
{
    /// <inheritdoc />
    public partial class RoadFactorFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "AccidentType",
            //     columns: table => new
            //     {
            //         AccidentTypeID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         TypeOfAccident = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AccidentType", x => x.AccidentTypeID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Collision",
            //     columns: table => new
            //     {
            //         CollisionID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         ColiisionType = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Collision", x => x.CollisionID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "District",
            //     columns: table => new
            //     {
            //         DistrictID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_District", x => x.DistrictID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "HumanFactor",
            //     columns: table => new
            //     {
            //         HumanFactorID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         HumanFactorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_HumanFactor", x => x.HumanFactorID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Lane",
            //     columns: table => new
            //     {
            //         LaneID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         LaneName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Lane", x => x.LaneID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Licence",
            //     columns: table => new
            //     {
            //         LicenceID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         TypeOfLicence = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Licence", x => x.LicenceID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "LoadCondition",
            //     columns: table => new
            //     {
            //         LoadConditionID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         LoadConditionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_LoadCondition", x => x.LoadConditionID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "LoadType",
            //     columns: table => new
            //     {
            //         LoadTypeID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         LoadTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_LoadType", x => x.LoadTypeID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Province",
            //     columns: table => new
            //     {
            //         ProvinceID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Province", x => x.ProvinceID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "RoadFeature",
            //     columns: table => new
            //     {
            //         RoadFeatureID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         RoadFeatureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_RoadFeature", x => x.RoadFeatureID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "RoadSurface",
            //     columns: table => new
            //     {
            //         RoadSurfaceID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         RoadSurfaceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_RoadSurface", x => x.RoadSurfaceID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "RoadSurfaceQuality",
            //     columns: table => new
            //     {
            //         RoadSurfaceQualityID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         RoadSurfaceQualityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_RoadSurfaceQuality", x => x.RoadSurfaceQualityID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "RoadType",
            //     columns: table => new
            //     {
            //         RoadTypeID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         RoadTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_RoadType", x => x.RoadTypeID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "SpeedLimit",
            //     columns: table => new
            //     {
            //         SpeedLimitID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         SpeedLimitNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_SpeedLimit", x => x.SpeedLimitID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "SurfaceCondition",
            //     columns: table => new
            //     {
            //         SurfaceConditionID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         SurfaceConditionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_SurfaceCondition", x => x.SurfaceConditionID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "TypeOfTrafficViolation",
            //     columns: table => new
            //     {
            //         TypeOfTrafficViolationID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         TypeOfTrafficViolationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_TypeOfTrafficViolation", x => x.TypeOfTrafficViolationID);
            //     });

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

            // migrationBuilder.CreateTable(
            //     name: "VehicleFactor",
            //     columns: table => new
            //     {
            //         VehicleFactorID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         VehicleFactorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_VehicleFactor", x => x.VehicleFactorID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "VehicleOwner",
            //     columns: table => new
            //     {
            //         VehicleOwnerID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         VehicleOwnerType = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_VehicleOwner", x => x.VehicleOwnerID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "VehicleType",
            //     columns: table => new
            //     {
            //         VehicleTypeID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         VehicleTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Weather",
            //     columns: table => new
            //     {
            //         WeatherTypeID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         TypeOfWeather = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Weather", x => x.WeatherTypeID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "PoliceStation",
            //     columns: table => new
            //     {
            //         PoliceStationID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         PoliceStationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         ProvinceID = table.Column<int>(type: "int", nullable: false),
            //         DistrictID = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_PoliceStation", x => x.PoliceStationID);
            //         table.ForeignKey(
            //             name: "FK_PoliceStation_District_DistrictID",
            //             column: x => x.DistrictID,
            //             principalTable: "District",
            //             principalColumn: "DistrictID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_PoliceStation_Province_ProvinceID",
            //             column: x => x.ProvinceID,
            //             principalTable: "Province",
            //             principalColumn: "ProvinceID",
            //             onDelete: ReferentialAction.Cascade);
            //     });

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
            //         Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
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

            // migrationBuilder.CreateTable(
            //     name: "AccidentReport",
            //     columns: table => new
            //     {
            //         AccidentReportID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         AccidentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         AccidentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         AccidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         AccidentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         AccidentSketch = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         AccidentPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         AccidentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         NrPeopleKilled = table.Column<int>(type: "int", nullable: false),
            //         NrPeopleInjured = table.Column<int>(type: "int", nullable: false),
            //         Confirmed = table.Column<bool>(type: "bit", nullable: false),
            //         HitAndRun = table.Column<bool>(type: "bit", nullable: false),
            //         AccountID = table.Column<int>(type: "int", nullable: false),
            //         PoliceStationID = table.Column<int>(type: "int", nullable: false),
            //         AccidentTypeID = table.Column<int>(type: "int", nullable: false),
            //         WeatherTypeID = table.Column<int>(type: "int", nullable: false),
            //         CollisionID = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AccidentReport", x => x.AccidentReportID);
            //         table.ForeignKey(
            //             name: "FK_AccidentReport_AccidentType_AccidentTypeID",
            //             column: x => x.AccidentTypeID,
            //             principalTable: "AccidentType",
            //             principalColumn: "AccidentTypeID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AccidentReport_Account_AccountID",
            //             column: x => x.AccountID,
            //             principalTable: "Account",
            //             principalColumn: "AccountID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AccidentReport_Collision_CollisionID",
            //             column: x => x.CollisionID,
            //             principalTable: "Collision",
            //             principalColumn: "CollisionID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AccidentReport_PoliceStation_PoliceStationID",
            //             column: x => x.PoliceStationID,
            //             principalTable: "PoliceStation",
            //             principalColumn: "PoliceStationID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AccidentReport_Weather_WeatherTypeID",
            //             column: x => x.WeatherTypeID,
            //             principalTable: "Weather",
            //             principalColumn: "WeatherTypeID",
            //             onDelete: ReferentialAction.Cascade);
            //     });

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

            // migrationBuilder.CreateTable(
            //     name: "AccidentFactor",
            //     columns: table => new
            //     {
            //         AccidentFactorID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         HumanFactorID = table.Column<int>(type: "int", nullable: false),
            //         VehicleFactorID = table.Column<int>(type: "int", nullable: false),
            //         AccidentReportID = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AccidentFactor", x => x.AccidentFactorID);
            //         table.ForeignKey(
            //             name: "FK_AccidentFactor_AccidentReport_AccidentReportID",
            //             column: x => x.AccidentReportID,
            //             principalTable: "AccidentReport",
            //             principalColumn: "AccidentReportID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AccidentFactor_HumanFactor_HumanFactorID",
            //             column: x => x.HumanFactorID,
            //             principalTable: "HumanFactor",
            //             principalColumn: "HumanFactorID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AccidentFactor_VehicleFactor_VehicleFactorID",
            //             column: x => x.VehicleFactorID,
            //             principalTable: "VehicleFactor",
            //             principalColumn: "VehicleFactorID",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            migrationBuilder.CreateTable(
                name: "RoadFactor",
                columns: table => new
                {
                    RoadFactorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoadNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalDivider = table.Column<bool>(type: "bit", nullable: false),
                    OnGoingRoadWorks = table.Column<bool>(type: "bit", nullable: false),
                    SurfaceConditionID = table.Column<int>(type: "int", nullable: false),
                    RoadTypeID = table.Column<int>(type: "int", nullable: false),
                    RoadFeatureID = table.Column<int>(type: "int", nullable: false),
                    RoadSurfaceID = table.Column<int>(type: "int", nullable: false),
                    RoadSurfaceQualityID = table.Column<int>(type: "int", nullable: false),
                    SpeedLimitID = table.Column<int>(type: "int", nullable: false),
                    LaneID = table.Column<int>(type: "int", nullable: false),
                    AccidentReportID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadFactor", x => x.RoadFactorID);
                    table.ForeignKey(
                        name: "FK_RoadFactor_AccidentReport_AccidentReportID",
                        column: x => x.AccidentReportID,
                        principalTable: "AccidentReport",
                        principalColumn: "AccidentReportID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadFactor_Lane_LaneID",
                        column: x => x.LaneID,
                        principalTable: "Lane",
                        principalColumn: "LaneID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadFactor_RoadFeature_RoadFeatureID",
                        column: x => x.RoadFeatureID,
                        principalTable: "RoadFeature",
                        principalColumn: "RoadFeatureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadFactor_RoadSurfaceQuality_RoadSurfaceQualityID",
                        column: x => x.RoadSurfaceQualityID,
                        principalTable: "RoadSurfaceQuality",
                        principalColumn: "RoadSurfaceQualityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadFactor_RoadSurface_RoadSurfaceID",
                        column: x => x.RoadSurfaceID,
                        principalTable: "RoadSurface",
                        principalColumn: "RoadSurfaceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadFactor_RoadType_RoadTypeID",
                        column: x => x.RoadTypeID,
                        principalTable: "RoadType",
                        principalColumn: "RoadTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadFactor_SpeedLimit_SpeedLimitID",
                        column: x => x.SpeedLimitID,
                        principalTable: "SpeedLimit",
                        principalColumn: "SpeedLimitID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoadFactor_SurfaceCondition_SurfaceConditionID",
                        column: x => x.SurfaceConditionID,
                        principalTable: "SurfaceCondition",
                        principalColumn: "SurfaceConditionID",
                        onDelete: ReferentialAction.Cascade);
                });

            // migrationBuilder.CreateTable(
            //     name: "Vehicle",
            //     columns: table => new
            //     {
            //         VehicleID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         MechanicalFailure = table.Column<bool>(type: "bit", nullable: false),
            //         VehicleTypeID = table.Column<int>(type: "int", nullable: false),
            //         LoadTypeID = table.Column<int>(type: "int", nullable: false),
            //         LoadConditionID = table.Column<int>(type: "int", nullable: false),
            //         AccidentReportID = table.Column<int>(type: "int", nullable: false),
            //         VehicleOwnerID = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Vehicle", x => x.VehicleID);
            //         table.ForeignKey(
            //             name: "FK_Vehicle_AccidentReport_AccidentReportID",
            //             column: x => x.AccidentReportID,
            //             principalTable: "AccidentReport",
            //             principalColumn: "AccidentReportID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_Vehicle_LoadCondition_LoadConditionID",
            //             column: x => x.LoadConditionID,
            //             principalTable: "LoadCondition",
            //             principalColumn: "LoadConditionID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_Vehicle_LoadType_LoadTypeID",
            //             column: x => x.LoadTypeID,
            //             principalTable: "LoadType",
            //             principalColumn: "LoadTypeID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_Vehicle_VehicleOwner_VehicleOwnerID",
            //             column: x => x.VehicleOwnerID,
            //             principalTable: "VehicleOwner",
            //             principalColumn: "VehicleOwnerID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_Vehicle_VehicleType_VehicleTypeID",
            //             column: x => x.VehicleTypeID,
            //             principalTable: "VehicleType",
            //             principalColumn: "VehicleTypeID",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "DriverInformation",
            //     columns: table => new
            //     {
            //         DriverInformationID = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Age = table.Column<int>(type: "int", nullable: false),
            //         Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         SafetyDevice = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         LicenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         AlcoholTested = table.Column<bool>(type: "bit", nullable: false),
            //         AlcoholSuspected = table.Column<bool>(type: "bit", nullable: false),
            //         VehicleID = table.Column<int>(type: "int", nullable: false),
            //         LicenceID = table.Column<int>(type: "int", nullable: false),
            //         TrafficViolationID = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_DriverInformation", x => x.DriverInformationID);
            //         table.ForeignKey(
            //             name: "FK_DriverInformation_Licence_LicenceID",
            //             column: x => x.LicenceID,
            //             principalTable: "Licence",
            //             principalColumn: "LicenceID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_DriverInformation_TypeOfTrafficViolation_TrafficViolationID",
            //             column: x => x.TrafficViolationID,
            //             principalTable: "TypeOfTrafficViolation",
            //             principalColumn: "TypeOfTrafficViolationID",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_DriverInformation_Vehicle_VehicleID",
            //             column: x => x.VehicleID,
            //             principalTable: "Vehicle",
            //             principalColumn: "VehicleID",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_AccidentFactor_AccidentReportID",
            //     table: "AccidentFactor",
            //     column: "AccidentReportID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AccidentFactor_HumanFactorID",
            //     table: "AccidentFactor",
            //     column: "HumanFactorID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AccidentFactor_VehicleFactorID",
            //     table: "AccidentFactor",
            //     column: "VehicleFactorID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AccidentReport_AccidentTypeID",
            //     table: "AccidentReport",
            //     column: "AccidentTypeID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AccidentReport_AccountID",
            //     table: "AccidentReport",
            //     column: "AccountID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AccidentReport_CollisionID",
            //     table: "AccidentReport",
            //     column: "CollisionID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AccidentReport_PoliceStationID",
            //     table: "AccidentReport",
            //     column: "PoliceStationID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AccidentReport_WeatherTypeID",
            //     table: "AccidentReport",
            //     column: "WeatherTypeID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Account_Id",
            //     table: "Account",
            //     column: "Id");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Address_AccountID",
            //     table: "Address",
            //     column: "AccountID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_DriverInformation_LicenceID",
            //     table: "DriverInformation",
            //     column: "LicenceID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_DriverInformation_TrafficViolationID",
            //     table: "DriverInformation",
            //     column: "TrafficViolationID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_DriverInformation_VehicleID",
            //     table: "DriverInformation",
            //     column: "VehicleID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_PoliceStation_DistrictID",
            //     table: "PoliceStation",
            //     column: "DistrictID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_PoliceStation_ProvinceID",
            //     table: "PoliceStation",
            //     column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_RoadFactor_AccidentReportID",
                table: "RoadFactor",
                column: "AccidentReportID");

            migrationBuilder.CreateIndex(
                name: "IX_RoadFactor_LaneID",
                table: "RoadFactor",
                column: "LaneID");

            migrationBuilder.CreateIndex(
                name: "IX_RoadFactor_RoadFeatureID",
                table: "RoadFactor",
                column: "RoadFeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_RoadFactor_RoadSurfaceID",
                table: "RoadFactor",
                column: "RoadSurfaceID");

            migrationBuilder.CreateIndex(
                name: "IX_RoadFactor_RoadSurfaceQualityID",
                table: "RoadFactor",
                column: "RoadSurfaceQualityID");

            migrationBuilder.CreateIndex(
                name: "IX_RoadFactor_RoadTypeID",
                table: "RoadFactor",
                column: "RoadTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RoadFactor_SpeedLimitID",
                table: "RoadFactor",
                column: "SpeedLimitID");

            migrationBuilder.CreateIndex(
                name: "IX_RoadFactor_SurfaceConditionID",
                table: "RoadFactor",
                column: "SurfaceConditionID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Vehicle_AccidentReportID",
            //     table: "Vehicle",
            //     column: "AccidentReportID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Vehicle_LoadConditionID",
            //     table: "Vehicle",
            //     column: "LoadConditionID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Vehicle_LoadTypeID",
            //     table: "Vehicle",
            //     column: "LoadTypeID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Vehicle_VehicleOwnerID",
            //     table: "Vehicle",
            //     column: "VehicleOwnerID");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Vehicle_VehicleTypeID",
            //     table: "Vehicle",
            //     column: "VehicleTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "AccidentFactor");

            // migrationBuilder.DropTable(
            //     name: "Address");

            // migrationBuilder.DropTable(
            //     name: "DriverInformation");

            migrationBuilder.DropTable(
                name: "RoadFactor");

            // migrationBuilder.DropTable(
            //     name: "HumanFactor");

            // migrationBuilder.DropTable(
            //     name: "VehicleFactor");

            // migrationBuilder.DropTable(
            //     name: "Licence");

            // migrationBuilder.DropTable(
            //     name: "TypeOfTrafficViolation");

            // migrationBuilder.DropTable(
            //     name: "Vehicle");

            // migrationBuilder.DropTable(
            //     name: "Lane");

            // migrationBuilder.DropTable(
            //     name: "RoadFeature");

            // migrationBuilder.DropTable(
            //     name: "RoadSurfaceQuality");

            // migrationBuilder.DropTable(
            //     name: "RoadSurface");

            // migrationBuilder.DropTable(
            //     name: "RoadType");

            // migrationBuilder.DropTable(
            //     name: "SpeedLimit");

            // migrationBuilder.DropTable(
            //     name: "SurfaceCondition");

            // migrationBuilder.DropTable(
            //     name: "AccidentReport");

            // migrationBuilder.DropTable(
            //     name: "LoadCondition");

            // migrationBuilder.DropTable(
            //     name: "LoadType");

            // migrationBuilder.DropTable(
            //     name: "VehicleOwner");

            // migrationBuilder.DropTable(
            //     name: "VehicleType");

            // migrationBuilder.DropTable(
            //     name: "AccidentType");

            // migrationBuilder.DropTable(
            //     name: "Account");

            // migrationBuilder.DropTable(
            //     name: "Collision");

            // migrationBuilder.DropTable(
            //     name: "PoliceStation");

            // migrationBuilder.DropTable(
            //     name: "Weather");

            // migrationBuilder.DropTable(
            //     name: "User");

            // migrationBuilder.DropTable(
            //     name: "District");

            // migrationBuilder.DropTable(
            //     name: "Province");
        }
    }
}
