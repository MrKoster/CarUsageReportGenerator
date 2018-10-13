using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDistanceGenerator.Models
{
    public class CarUsageTemplate
    {
        public List<string> TravelPurposes { get; set; }
        public List<string> RouteDescriptions { get; set; }
        public int MinKilometers { get; set; }
        public int MaxKilometers { get; set; }
    }
}
