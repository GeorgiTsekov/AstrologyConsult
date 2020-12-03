using Microsoft.EntityFrameworkCore.Migrations;

namespace AstrologyBlog.Data.Migrations
{
    public partial class removeVoteType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Votes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
