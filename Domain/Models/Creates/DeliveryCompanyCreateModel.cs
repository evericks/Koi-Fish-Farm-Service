namespace Domain.Models.Creates;

public class DeliveryCompanyCreateModel
{
    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Phone { get; set; } = null!;
}