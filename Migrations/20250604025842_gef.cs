using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GEF.Migrations
{
    /// <inheritdoc />
    public partial class gef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gef_Shelters",
                columns: table => new
                {
                    ShelterID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Quantity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Capacity = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gef_Shelters", x => x.ShelterID);
                });

            migrationBuilder.CreateTable(
                name: "Gef_User",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    BloodType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Weight = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    ResponsableName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(11)", maxLength: 11, nullable: false),
                    CardNumber = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    UserType = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ShelterID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gef_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Gef_User_Gef_Shelters_ShelterID",
                        column: x => x.ShelterID,
                        principalTable: "Gef_Shelters",
                        principalColumn: "ShelterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gef_Bracelets",
                columns: table => new
                {
                    BraceletID = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UserId = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LastBPM = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gef_Bracelets", x => x.BraceletID);
                    table.ForeignKey(
                        name: "FK_Gef_Bracelets_Gef_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Gef_User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gef_Bracelets_UserId",
                table: "Gef_Bracelets",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gef_User_ShelterID",
                table: "Gef_User",
                column: "ShelterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gef_Bracelets");

            migrationBuilder.DropTable(
                name: "Gef_User");

            migrationBuilder.DropTable(
                name: "Gef_Shelters");
        }
    }
}
