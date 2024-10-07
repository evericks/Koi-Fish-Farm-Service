using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class FishCategoryRepository: Repository<FishCategory>, IFishCategoryRepository
{
    public FishCategoryRepository(KoiFishFarmContext context) : base(context)
    {
    }
}