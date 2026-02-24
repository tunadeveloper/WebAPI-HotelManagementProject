using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataTransferObjectLayer.DTOs.HotelBookingKaggleDatasetDTOs
{
    public class ResultHotelBookingDTO
    {
        public string Hotel { get; set; }
        public int IsCanceled { get; set; }
        public int LeadTime { get; set; }
        public int ArrivalYear { get; set; }
        public string ArrivalMonth { get; set; }
        public double? WeekendNights { get; set; }
        public double? WeekNights { get; set; }
        public double? Adults { get; set; }
        public double? Children { get; set; }
        public double? Babies { get; set; }
        public string Country { get; set; }
        public string MarketSegment { get; set; }
        public string DistributionChannel { get; set; }
        public int IsRepeatedGuest { get; set; }
        public int PreviousCancellations { get; set; }
        public int PreviousNotCanceled { get; set; }
        public int BookingChanges { get; set; }
        public string DepositType { get; set; }
        public int DaysInWaitingList { get; set; }
        public string CustomerType { get; set; }
        public double ADR { get; set; }
        public int RequiredParkingSpaces { get; set; }
        public int TotalSpecialRequests { get; set; }
        public string ReservationStatus { get; set; }
    }
}
