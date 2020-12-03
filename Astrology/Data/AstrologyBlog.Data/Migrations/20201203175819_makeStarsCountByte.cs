using Microsoft.EntityFrameworkCore.Migrations;

namespace AstrologyBlog.Data.Migrations
{
    public partial class makeStarsCountByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "StarsCount",
                table: "Votes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StarsCount",
                table: "Votes",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
