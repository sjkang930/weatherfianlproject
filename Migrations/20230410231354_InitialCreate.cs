using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteWeathers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteWeathers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteWeatherUser",
                columns: table => new
                {
                    FavoriteWeathersId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteWeatherUser", x => new { x.FavoriteWeathersId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_FavoriteWeatherUser_FavoriteWeathers_FavoriteWeathersId",
                        column: x => x.FavoriteWeathersId,
                        principalTable: "FavoriteWeathers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteWeatherUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherDatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Temperature = table.Column<double>(type: "double precision", nullable: true),
                    Humidity = table.Column<double>(type: "double precision", nullable: true),
                    WindSpeed = table.Column<double>(type: "double precision", nullable: true),
                    Precipitation = table.Column<string>(type: "text", nullable: true),
                    rain = table.Column<double>(type: "double precision", nullable: true),
                    clouds = table.Column<double>(type: "double precision", nullable: true),
                    WeatherDescription = table.Column<string>(type: "text", nullable: true),
                    sunrise = table.Column<double>(type: "double precision", nullable: true),
                    sunset = table.Column<double>(type: "double precision", nullable: true),
                    feels_like = table.Column<double>(type: "double precision", nullable: true),
                    lat = table.Column<double>(type: "double precision", nullable: true),
                    lon = table.Column<double>(type: "double precision", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherDatas_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "FavoriteWeatherWeatherData",
                columns: table => new
                {
                    FavoriteWeathersId = table.Column<Guid>(type: "uuid", nullable: false),
                    WeatherDatasId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteWeatherWeatherData", x => new { x.FavoriteWeathersId, x.WeatherDatasId });
                    table.ForeignKey(
                        name: "FK_FavoriteWeatherWeatherData_FavoriteWeathers_FavoriteWeather~",
                        column: x => x.FavoriteWeathersId,
                        principalTable: "FavoriteWeathers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteWeatherWeatherData_WeatherDatas_WeatherDatasId",
                        column: x => x.WeatherDatasId,
                        principalTable: "WeatherDatas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteWeatherUser_UsersUserId",
                table: "FavoriteWeatherUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteWeatherWeatherData_WeatherDatasId",
                table: "FavoriteWeatherWeatherData",
                column: "WeatherDatasId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherDatas_UserId1",
                table: "WeatherDatas",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteWeatherUser");

            migrationBuilder.DropTable(
                name: "FavoriteWeatherWeatherData");

            migrationBuilder.DropTable(
                name: "FavoriteWeathers");

            migrationBuilder.DropTable(
                name: "WeatherDatas");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
