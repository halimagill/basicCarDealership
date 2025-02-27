using System;
using System.Collections.Generic;

namespace basicCarDealership_prep.data.Models;

public class Color
{
    public int ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
