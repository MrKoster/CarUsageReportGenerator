using System;

namespace CarDistanceGenerator.Models
{
    public class MonthDate
    {
        public int Year { get; set; }
        public int Month { get; set; }

        public MonthDate(int month, int year)
        {
            this.Year = year;
            this.Month = month;
        }
    }
}
