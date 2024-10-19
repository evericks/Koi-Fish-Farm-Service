namespace Domain.Models.Creates;

public class DriverCreateModel
{
    public string Name { get; set; } = null!;

    public Guid DeliveryCompanyId { get; set; }

    public string Phone { get; set; } = null!;

    public string Plates { get; set; } = null!;
}