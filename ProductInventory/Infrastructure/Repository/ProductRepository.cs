using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventory.Domain.Product;
using ProductInventory.Infrastructure.Context;
using ProductInventory.Infrastructure.Interface;
using ProductInventory.Infrastructure.Repository.Base;

namespace ProductInventory.Infrastructure.Repository
{
    public class ProductRepository : ProductInventoryRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductInventoryContext productInventoryContext) : base(productInventoryContext)
        {
        }
    }
}
