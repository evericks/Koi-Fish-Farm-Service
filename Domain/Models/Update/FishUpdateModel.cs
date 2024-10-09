using Microsoft.AspNetCore.Http;

namespace Domain.Models.Update;

public class FishUpdateModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Origin { get; set; } = null!;

    public int Size { get; set; }

    public IFormFile? Thumbnail { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int Price { get; set; }

    public int? PromotionPrice { get; set; }

    public Guid CreatorId { get; set; }

    public Guid? BatchId { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreateAt { get; set; }
}