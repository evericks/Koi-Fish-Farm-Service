using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Batch
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ThumbnailUrl { get; set; } = null!;

    public int Price { get; set; }

    public int? PromotionPrice { get; set; }

    public Guid CreatorId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual User Creator { get; set; } = null!;

    public virtual ICollection<Fish> Fish { get; set; } = new List<Fish>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
