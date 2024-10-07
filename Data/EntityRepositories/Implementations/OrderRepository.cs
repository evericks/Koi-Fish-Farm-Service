using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class OrderRepository: Repository<Order>, IOrderRepository
{
    public OrderRepository(KoiFishFarmContext context) : base(context)
    {
    }
}