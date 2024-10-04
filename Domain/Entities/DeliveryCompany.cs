using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DeliveryCompany
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Phone { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
