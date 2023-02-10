using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektiSentimentAnalysis.Migrations
{
    public partial class migrimi6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Feedbakcs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbakcs_UserId",
                table: "Feedbakcs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbakcs_AspNetUsers_UserId",
                table: "Feedbakcs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbakcs_AspNetUsers_UserId",
                table: "Feedbakcs");

            migrationBuilder.DropIndex(
                name: "IX_Feedbakcs_UserId",
                table: "Feedbakcs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Feedbakcs");
        }
    }
}
