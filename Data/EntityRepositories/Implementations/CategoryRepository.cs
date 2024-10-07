using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class CategoryRepository: Repository<Category>, ICategoryRepository
{
    public CategoryRepository(KoiFishFarmContext context) : base(context)
    {
    }
}