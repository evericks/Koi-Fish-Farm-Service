namespace Domain.Models.Views;

public class FeedbackViewModel
{
    public Guid Id { get; set; }

    public OrderViewModel Order { get; set; }

    public UserViewModel Customer { get; set; }

    public string? Message { get; set; }

    public int Star { get; set; }

    public DateTime? CreateAt { get; set; }
}