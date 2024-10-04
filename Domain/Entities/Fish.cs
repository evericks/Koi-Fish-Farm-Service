using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Fish
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Origin { get; set; } = null!;

    public int Size { get; set; }

    public string ThumbnailUrl { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int Price { get; set; }

    public int? PromotionPrice { get; set; }

    public Guid CreatorId { get; set; }

    public Guid? BatchId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual Batch? Batch { get; set; }

    public virtual User Creator { get; set; } = null!;

    public virtual ICollection<FishCategory> FishCategories { get; set; } = new List<FishCategory>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
