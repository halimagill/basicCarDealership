using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basicCarDealership_prep.data.Models;
using basicCarDealership_prep.Data.DTOs;
using basicCarDealership_prep1.Data.DTOs;

namespace basicCarDealership_prep.Data.Models
{
    public class VehicleSelectionDto
    {
        public List<ColorDto>? Colors { get; set; } = null;
        public List<MakeDto>? Makes { get; set; } = null;
        public bool? HasSunroof { get; set; } = null;
        public bool? IsFourWheelDrive { get; set; } = null;
        public bool? HasLowMiles { get; set; } = null;
        public bool? HasPowerWindows { get; set; } = null;
        public bool? HasNavigation { get; set; } = null;
        public bool? HasHeatedSeats { get; set; } = null;
        public int MinYear { get; set; } = 0;
        public int MaxYear { get; set; } = 99999;
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = 9999999.99M;
    }
}
