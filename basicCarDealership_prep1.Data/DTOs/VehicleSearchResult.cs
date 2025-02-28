using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basicCarDealership_prep.data.Models;

namespace basicCarDealership_prep.Data.DTOs
{
    public  class VehicleSearchResult
    {
        public Guid? _id { get; set; }

        public string? Make { get; set; }

        public int? Year { get; set; }

        public string? Color { get; set; }

        public decimal? Price { get; set; }

        public bool? HasSunroof { get; set; }

        public bool? IsFourWheelDrive { get; set; }

        public bool? HasLowMiles { get; set; }

        public bool? HasPowerWindows { get; set; }

        public bool? HasNavigation { get; set; }

        public bool? HasHeatedSeats { get; set; }        
    }
}
