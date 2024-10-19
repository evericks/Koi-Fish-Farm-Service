namespace Domain.Models.Views;

public class OrderViewModel
{
    public Guid Id { get; set; }

    public UserViewModel Customer { get; set; }

    public DriverViewModel? Driver { get; set; }

    public int Amount { get; set; }

    public string Receiver { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public bool IsPayment { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreateAt { get; set; }
    
    public ICollection<OrderDetailViewModel> OrderDetails { get; set; } = new List<OrderDetailViewModel>();
}