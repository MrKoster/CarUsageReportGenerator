using CarDistanceGenerator.Helpers;
using CarDistanceGenerator.Models;
using CarDistanceGenerator.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarDistanceGenerator.Logics
{
    public class CarGeneratorLogic
    {
        public void GenerateCarReport(int month, int year)
        {
            var monthDate = new MonthDate(month, year);
            var carUsages = this.GenerateRandomizedCarUsage(monthDate);
            PdfHelper.GeneratePdfToFile(carUsages);
        }

        private MonthlyCarUsage GenerateRandomizedCarUsage(MonthDate monthDate)
        {
            var monthlyUsage = new MonthlyCarUsage();
            var workDays = this.GetWorkDays(monthDate);
            for (int i = 0; i < workDays.Count; i++)
            {
                int workDay = workDays[i];
                var correctDate = new DateTime(monthDate.Year, monthDate.Month, workDay);
                var chosenTemplateResult = CarUsageRng.GetRandomizedCarUsage();
                monthlyUsage.Month = monthDate.Month;
                monthlyUsage.Year = monthDate.Year;
                monthlyUsage.CarUsages.Add(new DailyCarUsage()
                {
                    Number = i + 1,
                    Date = correctDate.ToString("dd.MM.yyyy"),
                    KilometersAmount = chosenTemplateResult.KilometersAmount,
                    RouteDescription = chosenTemplateResult.RouteDescriptions,
                    TravelPurpose = chosenTemplateResult.TravelPurposes,
                    OneKilometerRateValue = CarInfoRepository.GetCostRateValue()
                });
            }
            monthlyUsage.RecalculateAll();

            return monthlyUsage;
        }

        public List<int> GetWorkDays(MonthDate monthDate)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(monthDate.Year, monthDate.Month))
                   .Select(day => new DateTime(monthDate.Year, monthDate.Month, day))
                   .Where(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday).Select(x => x.Day).ToList();
        }





    }
}
