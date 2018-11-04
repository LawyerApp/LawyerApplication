using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LawyerApp.Migrations
{
    public partial class calendarmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Begin",
                table: "TeamMembers",
                nullable: false,
                defaultValue: (byte)9);

            migrationBuilder.AddColumn<byte>(
                name: "End",
                table: "TeamMembers",
                nullable: false,
                defaultValue: (byte)6);

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValue: new Guid("9ce471f6-cfb4-41d8-9515-34a795ec5a89")),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    WorkOrNot = table.Column<bool>(nullable: false, defaultValue: false),
                    Acceept = table.Column<bool>(nullable: false, defaultValue: false),
                    Email = table.Column<string>(nullable: true),
                    TeammemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_TeamMembers_TeammemberId",
                        column: x => x.TeammemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Date",
                table: "Schedules",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TeammemberId",
                table: "Schedules",
                column: "TeammemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropColumn(
                name: "Begin",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "End",
                table: "TeamMembers");
        }
    }
}
