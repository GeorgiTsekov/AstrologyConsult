using Microsoft.EntityFrameworkCore.Migrations;

namespace AstrologyBlog.Data.Migrations
{
    public partial class updateCategoryWithOneMorePropertyContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Categories");
        }
    }
}
