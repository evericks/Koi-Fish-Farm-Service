using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class DeliveryCompanyRepository: Repository<DeliveryCompany>, IDeliveryCompanyRepository
{
    public DeliveryCompanyRepository(KoiFishFarmContext context) : base(context)
    {
    }
}