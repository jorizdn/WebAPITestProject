using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventory.Domain.Category;
using ProductInventory.Infrastructure.Context;
using ProductInventory.Infrastructure.Interface;
using ProductInventory.Infrastructure.Repository.Base;

namespace ProductInventory.Infrastructure.Repository
{
    public class CategoryRepository : ProductInventoryRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductInventoryContext productInventoryContext) : base(productInventoryContext)
        {
        }
    }
}
