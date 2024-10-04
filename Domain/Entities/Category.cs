using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreateAt { get; set; }

    public virtual ICollection<FishCategory> FishCategories { get; set; } = new List<FishCategory>();
}
