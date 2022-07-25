using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumSystem.Data.Migrations
{
    public partial class AddVotes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_userId",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Votes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_userId",
                table: "Votes",
                newName: "IX_Votes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Votes",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                newName: "IX_Votes_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_userId",
                table: "Votes",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
