using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventory.Infrastructure;

namespace ProductInventory.Domain.Category
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public Category(string name)
        {
            Name = name;
        }
    }
}
