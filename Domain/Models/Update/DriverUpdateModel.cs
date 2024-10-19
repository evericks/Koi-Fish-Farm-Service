namespace Domain.Models.Update;

public class DriverUpdateModel
{
    public string? Name { get; set; }

    public Guid? DeliveryCompanyId { get; set; }

    public string? Status { get; set; }

    public string? Phone { get; set; }

    public string? Plates { get; set; }
}