using Microsoft.AspNetCore.Http;

namespace Domain.Models.Creates;

public class BatchCreateModel
{
    public string Name { get; set; } = null!;

    public int Price { get; set; }
    
    public IFormFile Thumbnail { get; set; }

    public int? PromotionPrice { get; set; }

    public ICollection<FishCreateModel> Fish { get; set; } = new List<FishCreateModel>();
}