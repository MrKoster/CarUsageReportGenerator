using System;
using System.Collections.Generic;
using System.Linq;


namespace CarDistanceGenerator.Models
{
    public class MonthlyCarUsage
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int TotalKilometersAmount { get; set; }
        public double TotalCostValue { get; set; }
        public List<DailyCarUsage> CarUsages { get; set; }

        public MonthlyCarUsage()
        {
            CarUsages = new List<DailyCarUsage>();
        }

        public MonthlyCarUsage(int year, int month)
        {
            this.Year = year;
            this.Month = month;
        }

        public void RecalculateAll()
        {
            this.RecalculateDailyCostValues();
            this.RecalculateTotalKilometers();
            this.RecalculateTotalCost();
        }

        private void RecalculateDailyCostValues()
        {
            foreach (var dailyUsage in CarUsages)
            {
                dailyUsage.SummedCostValue = dailyUsage.KilometersAmount * dailyUsage.OneKilometerRateValue;
                dailyUsage.SummedCostValue = Math.Round(dailyUsage.SummedCostValue, 2);
            }
        }

        private void RecalculateTotalCost()
        {
            TotalCostValue = this.CarUsages.Sum(x => x.SummedCostValue);
        }

        private void RecalculateTotalKilometers()
        {
            TotalKilometersAmount = this.CarUsages.Sum(x => x.KilometersAmount);
        }
    }
}
