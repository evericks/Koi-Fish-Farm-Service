namespace Domain.Models.Creates;

public class FeedbackCreateModel
{
    public Guid OrderId { get; set; }

    public Guid CustomerId { get; set; }

    public string? Message { get; set; }

    public int Star { get; set; }
}