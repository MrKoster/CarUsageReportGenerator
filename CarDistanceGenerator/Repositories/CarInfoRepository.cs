using System;

namespace CarDistanceGenerator.Repositories
{
    // TODO make user imput or settings.xml for parameters
    public static class CarInfoRepository
    {
        private const string DriverNameAndSurname = "Bruce Wayne";
        private const string FullCompanyName = "Wayne Industries";
        private const string CompanyStreet_PartOne = "1007 Mountain Drive";
        private const string CompanyStreet_PartTwo = "12-345 Gotham";
        private const string CarLicencePlate = "BAT-MAN 1234";
        private const string CarModelName = "Batmobile";
        private const string CarEngineCapacity = "infinite";
        private const double CostRateValue = 0.8358;

        public static string GetDriverNameAndSurname()
        {
            return DriverNameAndSurname;
        }

        public static string GetFullCompanyName()
        {
            return FullCompanyName;
        }

        public static string GetCompanyStreet_PartOne()
        {
            return CompanyStreet_PartOne;
        }

        public static string GetCompanyStreet_PartTwo()
        {
            return CompanyStreet_PartTwo;
        }

        public static string GetCarLicencePlate()
        {
            return CarLicencePlate;
        }

        public static string GetCarModelName()
        {
            return CarModelName;
        }

        public static string GetCarEngineCapacity()
        {
            return CarEngineCapacity;
        }

        public static double GetCostRateValue()
        {
            return CostRateValue;
        }

    }
}
