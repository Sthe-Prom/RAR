﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rar.Models;

#nullable disable

namespace rar.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230907211545_W_ID2")]
    partial class WID2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.2.22472.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("rar.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressID");

                    b.HasIndex("AccountID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("rar.Models.Repositories.AccidentReport", b =>
                {
                    b.Property<int>("AccidentReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccidentReportID"));

                    b.Property<DateTime>("AccidentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AccidentDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccidentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccidentLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AccidentTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("AccidentTypeID")
                        .HasColumnType("int");

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int>("AreaCodeID")
                        .HasColumnType("int");

                    b.Property<int>("CollisionID")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<int>("NrPeopleInjured")
                        .HasColumnType("int");

                    b.Property<int>("NrPeopleKilled")
                        .HasColumnType("int");

                    b.Property<int>("PoliceStationID")
                        .HasColumnType("int");

                    b.Property<int>("WeatherTypeID")
                        .HasColumnType("int");

                    b.HasKey("AccidentReportID");

                    b.HasIndex("AccidentTypeID");

                    b.HasIndex("AccountID");

                    b.HasIndex("AreaCodeID");

                    b.HasIndex("CollisionID");

                    b.HasIndex("PoliceStationID");

                    b.HasIndex("WeatherTypeID");

                    b.ToTable("AccidentReport");
                });

            modelBuilder.Entity("rar.Models.Repositories.AccidentType", b =>
                {
                    b.Property<int>("AccidentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccidentTypeID"));

                    b.Property<string>("TypeOfAccident")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccidentTypeID");

                    b.ToTable("AccidentType");
                });

            modelBuilder.Entity("rar.Models.Repositories.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"));

                    b.Property<string>("Cell")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdentityDoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MarriageDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.HasIndex("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("rar.Models.Repositories.AreaCode", b =>
                {
                    b.Property<int>("AreaCodeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaCodeID"));

                    b.Property<string>("AreaName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaCodeID");

                    b.ToTable("AreaCode");
                });

            modelBuilder.Entity("rar.Models.Repositories.Collision", b =>
                {
                    b.Property<int>("CollisionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollisionID"));

                    b.Property<string>("ColiisionType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollisionID");

                    b.ToTable("Collision");
                });

            modelBuilder.Entity("rar.Models.Repositories.District", b =>
                {
                    b.Property<int>("DistrictID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DistrictID"));

                    b.Property<string>("DistrictName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DistrictID");

                    b.ToTable("District");
                });

            modelBuilder.Entity("rar.Models.Repositories.PoliceStation", b =>
                {
                    b.Property<int>("PoliceStationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoliceStationID"));

                    b.Property<int>("DistrictID")
                        .HasColumnType("int");

                    b.Property<string>("PoliceStationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.HasKey("PoliceStationID");

                    b.HasIndex("DistrictID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("PoliceStation");
                });

            modelBuilder.Entity("rar.Models.Repositories.Province", b =>
                {
                    b.Property<int>("ProvinceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProvinceID"));

                    b.Property<string>("ProvinceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceID");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("rar.Models.Repositories.Weather", b =>
                {
                    b.Property<int>("WeatherTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeatherTypeID"));

                    b.Property<string>("TypeOfWeather")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeatherTypeID");

                    b.ToTable("Weather");
                });

            modelBuilder.Entity("rar.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("rar.Models.Address", b =>
                {
                    b.HasOne("rar.Models.Repositories.Account", "Account")
                        .WithMany("Address")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("rar.Models.Repositories.AccidentReport", b =>
                {
                    b.HasOne("rar.Models.Repositories.AccidentType", "AccidentType")
                        .WithMany()
                        .HasForeignKey("AccidentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rar.Models.Repositories.Account", "Account")
                        .WithMany("AccidentReport")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rar.Models.Repositories.AreaCode", "AreaCode")
                        .WithMany()
                        .HasForeignKey("AreaCodeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rar.Models.Repositories.Collision", "Collision")
                        .WithMany()
                        .HasForeignKey("CollisionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rar.Models.Repositories.PoliceStation", "PoliceStation")
                        .WithMany()
                        .HasForeignKey("PoliceStationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rar.Models.Repositories.Weather", "Weather")
                        .WithMany()
                        .HasForeignKey("WeatherTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccidentType");

                    b.Navigation("Account");

                    b.Navigation("AreaCode");

                    b.Navigation("Collision");

                    b.Navigation("PoliceStation");

                    b.Navigation("Weather");
                });

            modelBuilder.Entity("rar.Models.Repositories.Account", b =>
                {
                    b.HasOne("rar.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("rar.Models.Repositories.PoliceStation", b =>
                {
                    b.HasOne("rar.Models.Repositories.District", "District")
                        .WithMany("PoliceStation")
                        .HasForeignKey("DistrictID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("rar.Models.Repositories.Province", "Province")
                        .WithMany("PoliceStation")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("rar.Models.Repositories.Account", b =>
                {
                    b.Navigation("AccidentReport");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("rar.Models.Repositories.District", b =>
                {
                    b.Navigation("PoliceStation");
                });

            modelBuilder.Entity("rar.Models.Repositories.Province", b =>
                {
                    b.Navigation("PoliceStation");
                });
#pragma warning restore 612, 618
        }
    }
}
