namespace HotelManagement.EntityLayer.Concrete
{
    public class HotelBookingKaggleDataset
    {
        public int Id { get; set; }
        public string hotel { get; set; }
        public int is_canceled { get; set; }
        public int lead_time { get; set; }
        public int arrival_date_year { get; set; }
        public string arrival_date_month { get; set; }
        public int arrival_date_week_number { get; set; }
        public int arrival_date_day_of_month { get; set; }
        public double? stays_in_weekend_nights { get; set; }
        public double? stays_in_week_nights { get; set; }
        public double? adults { get; set; }
        public double? children { get; set; }
        public double? babies { get; set; }
        public string meal { get; set; }
        public string country { get; set; }
        public string market_segment { get; set; }
        public string distribution_channel { get; set; }
        public int is_repeated_guest { get; set; }
        public int previous_cancellations { get; set; }
        public int previous_bookings_not_canceled { get; set; }
        public string reserved_room_type { get; set; }
        public string assigned_room_type { get; set; }
        public int booking_changes { get; set; }
        public string deposit_type { get; set; }
        public string agent { get; set; }
        public string company { get; set; }
        public int days_in_waiting_list { get; set; }
        public string customer_type { get; set; }
        public double adr { get; set; }
        public int required_car_parking_spaces { get; set; }
        public int total_of_special_requests { get; set; }
        public string reservation_status { get; set; }
        public string reservation_status_date { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string credit_card { get; set; }
    }
}
