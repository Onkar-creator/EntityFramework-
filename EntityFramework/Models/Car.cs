using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Car
{
    public int Id { get; set; }

    public string? OwnerName { get; set; }

    public string? CarName { get; set; }

    public int? CarModelYear { get; set; }

    public string? FuelType { get; set; }

    public int? CarInsuranceYear { get; set; }
}
