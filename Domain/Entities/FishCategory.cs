using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FishCategory
{
    public Guid? Id { get; set; }

    public Guid FishId { get; set; }

    public Guid CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Fish Fish { get; set; } = null!;
}
