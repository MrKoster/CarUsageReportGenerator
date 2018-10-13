using CarDistanceGenerator.Models;
using System;
using System.Linq;

namespace CarDistanceGenerator.Helpers
{
    public static class CarUsageRng
    {
        public static Random Rng = new Random();

        public static CarUsageRandomizedResponse GetRandomizedCarUsage()
        {
            var allTemplates = Repositories.CarUsageTemplatesRepository.GetTemplates();

            var randomIndexForTemplate = Rng.Next(0, allTemplates.Count());
            var chosenTemplate = allTemplates[randomIndexForTemplate];

            var randomIndexForRouteDescription = Rng.Next(0, chosenTemplate.RouteDescriptions.Count());
            var chosenRouteDescription = chosenTemplate.RouteDescriptions[randomIndexForRouteDescription];

            var randomIndexForTravelPurposes = Rng.Next(0, chosenTemplate.TravelPurposes.Count());
            var chosenTravelPurposes = chosenTemplate.TravelPurposes[randomIndexForTravelPurposes];

            return new CarUsageRandomizedResponse()
            {
                KilometersAmount = Rng.Next(chosenTemplate.MinKilometers, chosenTemplate.MaxKilometers + 1),
                RouteDescriptions = chosenRouteDescription,
                TravelPurposes = chosenTravelPurposes
            };

        }

    }
}
