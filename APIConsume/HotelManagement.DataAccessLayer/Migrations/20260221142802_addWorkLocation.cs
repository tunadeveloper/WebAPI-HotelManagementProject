using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addWorkLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkLocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationId",
                table: "AspNetUsers",
                column: "WorkLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationId",
                table: "AspNetUsers",
                column: "WorkLocationId",
                principalTable: "WorkLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WorkLocations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationId",
                table: "AspNetUsers");
        }
    }
}
