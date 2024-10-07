using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class FishRepository: Repository<Fish>, IFishRepository
{
    public FishRepository(KoiFishFarmContext context) : base(context)
    {
    }
}