﻿namespace Domain.Models.Update;

public class DeliveryCompanyUpdateModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Phone { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime CreateAt { get; set; }
}