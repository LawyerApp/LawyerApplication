using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LawyerApp.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Schedules",
                nullable: false,
                defaultValue: new Guid("46f1d167-6b43-43fb-84c7-2f7af2c5833d"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("5c84fca5-9c98-4a60-a1db-508264cae5ef"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Schedules",
                nullable: false,
                defaultValue: new Guid("5c84fca5-9c98-4a60-a1db-508264cae5ef"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("46f1d167-6b43-43fb-84c7-2f7af2c5833d"));
        }
    }
}
