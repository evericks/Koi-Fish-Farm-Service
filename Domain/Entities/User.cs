using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string Status { get; set; } = null!;

    public Guid RoleId { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<Batch> Batches { get; set; } = new List<Batch>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Fish> Fish { get; set; } = new List<Fish>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;
}
