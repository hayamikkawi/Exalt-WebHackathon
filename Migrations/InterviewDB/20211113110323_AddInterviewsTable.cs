using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace loginAPI.Migrations.InterviewDB
{
    public partial class AddInterviewsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateName = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: false),
                    InterViewerName = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    HallID = table.Column<int>(nullable: false),
                    Branch = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interviews");
        }
    }
}
