using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventory.Domain.Product;
using ProductInventory.Infrastructure.Interface.Base;

namespace ProductInventory.Infrastructure.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
    }
}
