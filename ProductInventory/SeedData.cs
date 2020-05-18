using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductInventory.Domain.Category;
using ProductInventory.Domain.Product;
using ProductInventory.Domain.User;
using ProductInventory.Infrastructure.Context;

namespace ProductInventory
{
    public static class SeedData
    { 
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductInventoryContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProductInventoryContext>>()))
            {
                var user1 = new User("Joriz");

                if (!context.Users.Any())
                {

                    context.Users.AddRange(
                        user1
                    );
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product("Milo", "Chocolate drink", 1, "some link here"),
                        new Product("Bear brand", "Milk drink", 1, "some link here"),
                        new Product("Slippers", "rubber", 2, "some link here"),
                        new Product("T-shirt", "clothes", 2, "some link here")
                    );
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category("Food"),
                        new Category("Clothes")
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
