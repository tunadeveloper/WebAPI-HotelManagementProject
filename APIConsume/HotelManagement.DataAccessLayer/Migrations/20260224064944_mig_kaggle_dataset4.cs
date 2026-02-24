using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_kaggle_dataset4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "stays_in_weekend_nights",
                table: "hotelBookingKaggleDatasets",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "stays_in_week_nights",
                table: "hotelBookingKaggleDatasets",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "children",
                table: "hotelBookingKaggleDatasets",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "babies",
                table: "hotelBookingKaggleDatasets",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "adults",
                table: "hotelBookingKaggleDatasets",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "stays_in_weekend_nights",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "stays_in_week_nights",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "children",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "babies",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "adults",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
