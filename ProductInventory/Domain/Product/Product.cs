using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductInventory.Infrastructure;

namespace ProductInventory.Domain.Product
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int CategoryId { get; private set; }
        public string Image { get; private set; } //might be link to the bucket
        
        public Product(string name, string description, int categoryId, string image)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Image = image;
        }

        public virtual void Update(string name, string description, int categoryId, string image)
        {
            Name = string.IsNullOrEmpty(name) ? Name : name;
            Description = string.IsNullOrEmpty(description) ? Description : description;
            CategoryId = categoryId < 1 ? CategoryId : categoryId;
            Image = string.IsNullOrEmpty(image) ? Image : image;
        }
    }
}
