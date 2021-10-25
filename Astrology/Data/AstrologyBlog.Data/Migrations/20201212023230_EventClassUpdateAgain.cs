namespace AstrologyBlog.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EventClassUpdateAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");
        }
    }
}
