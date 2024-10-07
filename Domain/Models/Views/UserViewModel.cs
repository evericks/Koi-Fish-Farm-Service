namespace Domain.Models.Views;

public class UserViewModel
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string Status { get; set; } = null!;

    public RoleViewModel Role { get; set; }

    public DateTime CreateAt { get; set; }
}