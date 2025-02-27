using System;
using System.Collections.Generic;

namespace basicCarDealership_prep.data.Models;

public class Car
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

    public virtual Color Color { get; set; } = null!;

    public virtual Make Make { get; set; } = null!;
}
