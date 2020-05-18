using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductInventory.Domain.Category;
using ProductInventory.Domain.Product;
using ProductInventory.Domain.User;

namespace ProductInventory.Infrastructure.Context
{
    public class ProductInventoryContext : DbContext
    {
        private readonly IMediator _mediator;

        public ProductInventoryContext(DbContextOptions<ProductInventoryContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public ProductInventoryContext(DbContextOptions<ProductInventoryContext> dbContextOptions, IMediator mediator) : base(dbContextOptions)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result > 0 ? true : false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
