using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektiSentimentAnalysis.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fakultetis",
                columns: table => new
                {
                    FakultetiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitulliDiplomimit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakultetis", x => x.FakultetiId);
                });

            migrationBuilder.CreateTable(
                name: "Institutis",
                columns: table => new
                {
                    InstitutiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacioni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrStudenteve = table.Column<int>(type: "int", nullable: false),
                    Nrtelefonit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutis", x => x.InstitutiId);
                });

            migrationBuilder.CreateTable(
                name: "Feedbakcs",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permbajtja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstitutiId = table.Column<int>(type: "int", nullable: false),
                    FakultetiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbakcs", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedbakcs_Fakultetis_FakultetiId",
                        column: x => x.FakultetiId,
                        principalTable: "Fakultetis",
                        principalColumn: "FakultetiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedbakcs_Institutis_InstitutiId",
                        column: x => x.InstitutiId,
                        principalTable: "Institutis",
                        principalColumn: "InstitutiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Infks",
                columns: table => new
                {
                    InfkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusiAkredititmit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VitiAkreditimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FakultetiId = table.Column<int>(type: "int", nullable: false),
                    InstitutiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infks", x => x.InfkId);
                    table.ForeignKey(
                        name: "FK_Infks_Fakultetis_FakultetiId",
                        column: x => x.FakultetiId,
                        principalTable: "Fakultetis",
                        principalColumn: "FakultetiId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Infks_Institutis_InstitutiId",
                        column: x => x.InstitutiId,
                        principalTable: "Institutis",
                        principalColumn: "InstitutiId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbakcs_FakultetiId",
                table: "Feedbakcs",
                column: "FakultetiId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbakcs_InstitutiId",
                table: "Feedbakcs",
                column: "InstitutiId");

            migrationBuilder.CreateIndex(
                name: "IX_Infks_FakultetiId",
                table: "Infks",
                column: "FakultetiId");

            migrationBuilder.CreateIndex(
                name: "IX_Infks_InstitutiId",
                table: "Infks",
                column: "InstitutiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbakcs");

            migrationBuilder.DropTable(
                name: "Infks");

            migrationBuilder.DropTable(
                name: "Fakultetis");

            migrationBuilder.DropTable(
                name: "Institutis");
        }
    }
}
