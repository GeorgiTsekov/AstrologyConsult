namespace AstrologyBlog.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EventClassUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_ArticlesCategories_ArticlesCategoryId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ArticlesCategoryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ArticlesCategoryId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "ArticlesCategoryId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Events_ArticlesCategoryId",
                table: "Events",
                column: "ArticlesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_ArticlesCategories_ArticlesCategoryId",
                table: "Events",
                column: "ArticlesCategoryId",
                principalTable: "ArticlesCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
