using System;

namespace CarDistanceGenerator.Models
{
    public class DailyCarUsage
    {
        public int Number { get; set; }
        public string Date { get; set; }
        public string RouteDescription { get; set; }
        public string TravelPurpose { get; set; }
        public int KilometersAmount { get; set; }
        public double OneKilometerRateValue { get; set; }
        public double SummedCostValue { get; set; }
        public string Remarks { get; set; }
    }
}
