using System;

namespace WE_55_API.Models

{
    public class TimeSlot
    {
        public int TSId { get; set; }
        public string TSCode { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Status { get; set; }

    }
}