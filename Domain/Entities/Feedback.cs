﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Feedback
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid CustomerId { get; set; }

    public string? Message { get; set; }

    public int Star { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
