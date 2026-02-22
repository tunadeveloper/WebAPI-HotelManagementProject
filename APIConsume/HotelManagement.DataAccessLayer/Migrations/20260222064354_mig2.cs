using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "WorkLocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "WorkLocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationId",
                table: "AspNetUsers",
                column: "WorkLocationId",
                principalTable: "WorkLocations",
                principalColumn: "Id");
        }
    }
}
