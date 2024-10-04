using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Driver
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid DeliveryCompanyId { get; set; }

    public string Status { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Plates { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual DeliveryCompany DeliveryCompany { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
