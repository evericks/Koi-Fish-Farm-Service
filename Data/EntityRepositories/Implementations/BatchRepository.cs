using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class BatchRepository: Repository<Batch>, IBatchRepository
{
    public BatchRepository(KoiFishFarmContext context) : base(context)
    {
    }
}