using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderDetail
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid? FishId { get; set; }

    public Guid? BatchId { get; set; }

    public int Price { get; set; }

    public virtual Batch? Batch { get; set; }

    public virtual Fish? Fish { get; set; }

    public virtual Order Order { get; set; } = null!;
}
