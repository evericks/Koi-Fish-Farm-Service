using Data.EntityRepositories.Interfaces;
using Data.Repositories.Implementations;
using Domain.Context;
using Domain.Entities;

namespace Data.EntityRepositories.Implementations;

public class UserRepository: Repository<User>, IUserRepository
{
    public UserRepository(KoiFishFarmContext context) : base(context)
    {
    }
}