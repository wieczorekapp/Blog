using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataLayer.Migrations
{
    public partial class AddCreatedDateToPostsTagsMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsTagsMap_Posts_PostsId",
                table: "PostsTagsMap");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsTagsMap_Tags_TagsId",
                table: "PostsTagsMap");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "PostsTagsMap",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "PostsId",
                table: "PostsTagsMap",
                newName: "PostId");

            migrationBuilder.RenameIndex(
                name: "IX_PostsTagsMap_TagsId",
                table: "PostsTagsMap",
                newName: "IX_PostsTagsMap_TagId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PostsTagsMap",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddForeignKey(
                name: "FK_PostsTagsMap_Posts_PostId",
                table: "PostsTagsMap",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostsTagsMap_Tags_TagId",
                table: "PostsTagsMap",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostsTagsMap_Posts_PostId",
                table: "PostsTagsMap");

            migrationBuilder.DropForeignKey(
                name: "FK_PostsTagsMap_Tags_TagId",
                table: "PostsTagsMap");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PostsTagsMap");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "PostsTagsMap",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "PostsTagsMap",
                newName: "PostsId");

            migrationBuilder.RenameIndex(
                name: "IX_PostsTagsMap_TagId",
                table: "PostsTagsMap",
                newName: "IX_PostsTagsMap_TagsId");

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
    }
}
