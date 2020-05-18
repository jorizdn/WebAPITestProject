using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductInventory.Infrastructure
{
    public abstract class Entity
    {
        [Key]
        public virtual int Id { get; protected set; }
    }
}
