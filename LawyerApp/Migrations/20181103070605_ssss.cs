using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LawyerApp.Migrations
{
    public partial class ssss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Schedules",
                nullable: false,
                defaultValue: new Guid("5c84fca5-9c98-4a60-a1db-508264cae5ef"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("9ce471f6-cfb4-41d8-9515-34a795ec5a89"));

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Schedules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Schedules");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Schedules",
                nullable: false,
                defaultValue: new Guid("9ce471f6-cfb4-41d8-9515-34a795ec5a89"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("5c84fca5-9c98-4a60-a1db-508264cae5ef"));
        }
    }
}
