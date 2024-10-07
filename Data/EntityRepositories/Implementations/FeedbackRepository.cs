using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class FeedbackRepository: Repository<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(KoiFishFarmContext context) : base(context)
    {
    }
}