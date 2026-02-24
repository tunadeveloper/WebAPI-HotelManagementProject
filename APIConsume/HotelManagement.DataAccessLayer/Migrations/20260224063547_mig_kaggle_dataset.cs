using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_kaggle_dataset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotelBookingKaggleDatasets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAdults = table.Column<int>(type: "int", nullable: false),
                    TotalChildren = table.Column<int>(type: "int", nullable: false),
                    TotalBabies = table.Column<int>(type: "int", nullable: false),
                    TotalWeekendNights = table.Column<int>(type: "int", nullable: false),
                    TotalWeekNights = table.Column<int>(type: "int", nullable: false),
                    AverageADR = table.Column<double>(type: "float", nullable: false),
                    TotalBookings = table.Column<int>(type: "int", nullable: false),
                    TotalCanceledBookings = table.Column<int>(type: "int", nullable: false),
                    TopCountries = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelBookingKaggleDatasets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hotelBookingKaggleDatasets");
        }
    }
}
