namespace Domain.Models.Views;

public class DriverViewModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DeliveryCompanyViewModel DeliveryCompany { get; set; }

    public string Status { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Plates { get; set; } = null!;

    public DateTime CreateAt { get; set; }
}