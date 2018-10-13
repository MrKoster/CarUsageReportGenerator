using CarDistanceGenerator.Models;
using System.Collections.Generic;

namespace CarDistanceGenerator.Repositories
{
    public static class CarUsageTemplatesRepository
    {
        // TODO templates should be importable, not hardcoded

        // Template zawiera 4 pola
        // Dla każdego wiersza w kilometrówce najpierw losowany jest template, a nastęie
        // losowane są wartości z wybranego template'u
        // RouteDescriptions to możliwości dla "Opis trasy wyjadu "
        // TravelPurposes to możliwości dla Cel wyjazdu
        // Min i Max kilometers to przedział losowania ilości kilometrów dla wiersza

        private static readonly List<CarUsageTemplate> Templates = new List<CarUsageTemplate>()
        {
            new CarUsageTemplate()
            {
                RouteDescriptions =  new List<string>(){ "Gotham", "Central City", "Starling City", "Atlantis" },
                TravelPurposes = new List<string>(){ "Meeting with client", "Saving the day", "Invading Apocalipse planet", "Driking coffie" },
                MinKilometers = 10,
                MaxKilometers = 500
            },
            //new CarUsageTemplate()
            //{
            //    RouteDescriptions =  new List<string>(){ "Gotham", "Central City", "Starling City", "Atlantis" },
            //    TravelPurposes = new List<string>(){ "Meeting with client", "Saving the day", "Invading Apocalipse planet", "Driking coffie" },
            //    MinKilometers = 10,
            //    MaxKilometers = 500
            //},
        };

        public static List<CarUsageTemplate> GetTemplates()
        {
            return Templates;
        }


    }
}
