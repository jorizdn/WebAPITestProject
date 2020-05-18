using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventory.Domain.User;
using ProductInventory.Infrastructure.Context;
using ProductInventory.Infrastructure.Interface;
using ProductInventory.Infrastructure.Repository.Base;

namespace ProductInventory.Infrastructure.Repository
{
    public class UserRepository : ProductInventoryRepository<User>, IUserRepository
    {
        public UserRepository(ProductInventoryContext productInventoryContext) : base(productInventoryContext)
        {
        }
    }
}
