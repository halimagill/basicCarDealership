using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basicCarDealership_prep.data.Models
{
    public class VehicleSearchViewModel
    {
        public Guid CarId { get; set; }

        public int MakeId { get; set; }

        public int? Year { get; set; }

        public int ColorId { get; set; }

        public decimal Price { get; set; }

        public bool HasSunroof { get; set; }

        public bool IsFourWheelDrive { get; set; }

        public bool HasLowMiles { get; set; }

        public bool HasPowerWindows { get; set; }

        public bool HasNavigation { get; set; }

        public bool HasHeatedSeats { get; set; }

        public string ColorName { get; set; } = null!;

        public string MakeName { get; set; } = null!;
    }
}
