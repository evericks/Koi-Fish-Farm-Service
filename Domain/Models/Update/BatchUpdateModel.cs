using Microsoft.AspNetCore.Http;

namespace Domain.Models.Update;

public class BatchUpdateModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public IFormFile? Thumbnail { get; set; } = null!;

    public int Price { get; set; }

    public int? PromotionPrice { get; set; }

    public Guid CreatorId { get; set; }

    public DateTime CreateAt { get; set; }
}