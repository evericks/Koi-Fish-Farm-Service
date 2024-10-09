using Microsoft.AspNetCore.Http;

namespace Domain.Models.Creates;

public class FishCreateModel
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Origin { get; set; } = null!;
    
    public IFormFile Thumbnail { get; set; }

    public int Size { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int Price { get; set; }

    public int? PromotionPrice { get; set; }
    
    public virtual ICollection<FishCategoryCreateModel> FishCategories { get; set; } = new List<FishCategoryCreateModel>();

}