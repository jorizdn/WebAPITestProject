using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventory.Domain.User;
using ProductInventory.Infrastructure.Interface.Base;

namespace ProductInventory.Infrastructure.Interface
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
