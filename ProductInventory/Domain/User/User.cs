using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventory.Infrastructure;

namespace ProductInventory.Domain.User
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public virtual ICollection<Product.Product> Products { get; } = new List<Product.Product>();

        public User(string name)
        {
            Name = name;
        }

    }
}
