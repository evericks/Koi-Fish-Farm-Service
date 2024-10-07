using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class OrderDetailRepository: Repository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(KoiFishFarmContext context) : base(context)
    {
    }
}