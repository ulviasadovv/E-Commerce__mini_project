using ECommerce.Domain.Entities.Models;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.EfCore.Context;
using ECommerce.Infrastructure.EfCore.Core;

namespace ECommerce.Infrastructure.EfCore;

public class UserRepository : EfCoreRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
