using Microsoft.EntityFrameworkCore.Migrations;

namespace AstrologyBlog.Data.Migrations
{
    public partial class updateVoteClassWithNewPropertyStarsCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StarsCount",
                table: "Votes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StarsCount",
                table: "Votes");
        }
    }
}
