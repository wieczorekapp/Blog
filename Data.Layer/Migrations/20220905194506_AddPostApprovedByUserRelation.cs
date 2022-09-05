using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataLayer.Migrations
{
    public partial class AddPostApprovedByUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovedByUserId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApprovedByUserId",
                table: "Posts",
                column: "ApprovedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_ApprovedByUserId",
                table: "Posts",
                column: "ApprovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_ApprovedByUserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ApprovedByUserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ApprovedByUserId",
                table: "Posts");
        }
    }
}
