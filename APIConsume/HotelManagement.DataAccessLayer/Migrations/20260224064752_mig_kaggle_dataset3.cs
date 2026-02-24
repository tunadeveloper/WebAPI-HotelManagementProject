using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_kaggle_dataset3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "hotelBookingKaggleDatasets",
                newName: "total_of_special_requests");

            migrationBuilder.RenameColumn(
                name: "TotalWeekendNights",
                table: "hotelBookingKaggleDatasets",
                newName: "stays_in_weekend_nights");

            migrationBuilder.RenameColumn(
                name: "TotalWeekNights",
                table: "hotelBookingKaggleDatasets",
                newName: "stays_in_week_nights");

            migrationBuilder.RenameColumn(
                name: "TotalChildren",
                table: "hotelBookingKaggleDatasets",
                newName: "required_car_parking_spaces");

            migrationBuilder.RenameColumn(
                name: "TotalCanceledBookings",
                table: "hotelBookingKaggleDatasets",
                newName: "previous_cancellations");

            migrationBuilder.RenameColumn(
                name: "TotalBookings",
                table: "hotelBookingKaggleDatasets",
                newName: "previous_bookings_not_canceled");

            migrationBuilder.RenameColumn(
                name: "TotalBabies",
                table: "hotelBookingKaggleDatasets",
                newName: "lead_time");

            migrationBuilder.RenameColumn(
                name: "TotalAdults",
                table: "hotelBookingKaggleDatasets",
                newName: "is_repeated_guest");

            migrationBuilder.RenameColumn(
                name: "TopCountries",
                table: "hotelBookingKaggleDatasets",
                newName: "reserved_room_type");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "hotelBookingKaggleDatasets",
                newName: "reservation_status_date");

            migrationBuilder.RenameColumn(
                name: "AverageADR",
                table: "hotelBookingKaggleDatasets",
                newName: "adr");

            migrationBuilder.AddColumn<int>(
                name: "adults",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "agent",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "arrival_date_day_of_month",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "arrival_date_month",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "arrival_date_week_number",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "arrival_date_year",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "assigned_room_type",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "babies",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "booking_changes",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "children",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "company",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "credit_card",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "customer_type",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "days_in_waiting_list",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "deposit_type",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "distribution_channel",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "hotel",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "is_canceled",
                table: "hotelBookingKaggleDatasets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "market_segment",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "meal",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "reservation_status",
                table: "hotelBookingKaggleDatasets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adults",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "agent",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "arrival_date_day_of_month",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "arrival_date_month",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "arrival_date_week_number",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "arrival_date_year",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "assigned_room_type",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "babies",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "booking_changes",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "children",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "company",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "country",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "credit_card",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "customer_type",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "days_in_waiting_list",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "deposit_type",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "distribution_channel",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "email",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "hotel",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "is_canceled",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "market_segment",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "meal",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "name",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.DropColumn(
                name: "reservation_status",
                table: "hotelBookingKaggleDatasets");

            migrationBuilder.RenameColumn(
                name: "total_of_special_requests",
                table: "hotelBookingKaggleDatasets",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "stays_in_weekend_nights",
                table: "hotelBookingKaggleDatasets",
                newName: "TotalWeekendNights");

            migrationBuilder.RenameColumn(
                name: "stays_in_week_nights",
                table: "hotelBookingKaggleDatasets",
                newName: "TotalWeekNights");

            migrationBuilder.RenameColumn(
                name: "reserved_room_type",
                table: "hotelBookingKaggleDatasets",
                newName: "TopCountries");

            migrationBuilder.RenameColumn(
                name: "reservation_status_date",
                table: "hotelBookingKaggleDatasets",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "required_car_parking_spaces",
                table: "hotelBookingKaggleDatasets",
                newName: "TotalChildren");

            migrationBuilder.RenameColumn(
                name: "previous_cancellations",
                table: "hotelBookingKaggleDatasets",
                newName: "TotalCanceledBookings");

            migrationBuilder.RenameColumn(
                name: "previous_bookings_not_canceled",
                table: "hotelBookingKaggleDatasets",
                newName: "TotalBookings");

            migrationBuilder.RenameColumn(
                name: "lead_time",
                table: "hotelBookingKaggleDatasets",
                newName: "TotalBabies");

            migrationBuilder.RenameColumn(
                name: "is_repeated_guest",
                table: "hotelBookingKaggleDatasets",
                newName: "TotalAdults");

            migrationBuilder.RenameColumn(
                name: "adr",
                table: "hotelBookingKaggleDatasets",
                newName: "AverageADR");
        }
    }
}
