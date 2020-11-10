using Microsoft.EntityFrameworkCore.Migrations;

namespace MDGriphe.Experiments.Lumia950.WebHost.Migrations
{
    public partial class Index1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Visit_Created",
                schema: "dbo",
                table: "Visit",
                column: "Created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visit_Created",
                schema: "dbo",
                table: "Visit");
        }
    }
}
