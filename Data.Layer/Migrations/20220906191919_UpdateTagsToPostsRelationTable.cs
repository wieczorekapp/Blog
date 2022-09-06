using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataLayer.Migrations
{
    public partial class UpdateTagsToPostsRelationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostsId",
                table: "PostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Tags_TagsId",
                table: "PostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag");

            migrationBuilder.RenameTable(
                name: "PostTag",
                newName: "PostsTagsMap");

            migrationBuilder.RenameIndex(
                name: "IX_PostTag_TagsId",
                table: "PostsTagsMap",
                newName: "IX_PostsTagsMap_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostsTagsMap",
                table: "PostsTagsMap",
                columns: new[] { "PostsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostsTagsMap_Posts_PostsId",
                table: "PostsTagsMap",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsTagsMap_Tags_TagsId",
                table: "PostsTagsMap",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsTagsMap_Posts_PostsId",
                table: "PostsTagsMap");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsTagsMap_Tags_TagsId",
                table: "PostsTagsMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostsTagsMap",
                table: "PostsTagsMap");

            migrationBuilder.RenameTable(
                name: "PostsTagsMap",
                newName: "PostTag");

            migrationBuilder.RenameIndex(
                name: "IX_PostsTagsMap_TagsId",
                table: "PostTag",
                newName: "IX_PostTag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTag",
                table: "PostTag",
                columns: new[] { "PostsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostsId",
                table: "PostTag",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Tags_TagsId",
                table: "PostTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
