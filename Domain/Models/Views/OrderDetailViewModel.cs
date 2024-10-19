namespace Domain.Models.Views;

public class OrderDetailViewModel
{
    public Guid Id { get; set; }

    public FishViewModel? Fish { get; set; }

    public BatchViewModel? Batch { get; set; }

    public int Price { get; set; }
}