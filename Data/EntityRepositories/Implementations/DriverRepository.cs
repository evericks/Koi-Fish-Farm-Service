using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class DriverRepository: Repository<Driver>, IDriverRepository
{
    public DriverRepository(KoiFishFarmContext context) : base(context)
    {
    }
}