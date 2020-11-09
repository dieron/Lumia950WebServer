using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MDGriphe.Experiments.Lumia950.WebHost.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Visit",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(nullable: false),
                    IP = table.Column<string>(maxLength: 15, nullable: true),
                    VisitorId = table.Column<string>(nullable: true),
                    Query = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Headers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visit",
                schema: "dbo");
        }
    }
}
