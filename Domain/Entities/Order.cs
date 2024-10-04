﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid? DriverId { get; set; }

    public int Amount { get; set; }

    public string Receiver { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public bool IsPayment { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual Driver? Driver { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
