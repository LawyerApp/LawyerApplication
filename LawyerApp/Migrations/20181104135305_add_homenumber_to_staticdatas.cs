using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LawyerApp.Migrations
{
    public partial class add_homenumber_to_staticdatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactHomeNumber",
                table: "StaticDatas",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Schedules",
                nullable: false,
                defaultValue: new Guid("9581af79-ca50-45da-b2e8-7c1e88daa929"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("46f1d167-6b43-43fb-84c7-2f7af2c5833d"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactHomeNumber",
                table: "StaticDatas");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Schedules",
                nullable: false,
                defaultValue: new Guid("46f1d167-6b43-43fb-84c7-2f7af2c5833d"),
                oldClrType: typeof(Guid),
                oldDefaultValue: new Guid("9581af79-ca50-45da-b2e8-7c1e88daa929"));
        }
    }
}
