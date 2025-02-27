using System;
using System.Collections.Generic;

namespace basicCarDealership_prep.data.Models;

public class Make
{
    public int MakeId { get; set; }

    public string MakeName { get; set; } = null!;

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
