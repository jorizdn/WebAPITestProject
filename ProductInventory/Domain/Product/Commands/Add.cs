using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductInventory.Infrastructure.Interface;

namespace ProductInventory.Domain.Product.Commands
{
    public class AddProduct : IRequest<bool>
    {
        [DataMember] public string Name { get; private set; }
        [DataMember] public string Description { get; private set; }
        [DataMember] public int CategoryId { get; private set; }
        [DataMember] public string Image { get; private set; }

        public AddProduct(string name, string description, int categoryId, string image)
        {
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Image = image;
        }
    }

    public class AddProductHandler : IRequestHandler<AddProduct, bool>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            var product = new Product( request.Name, request.Description, request.CategoryId, request.Image); 
            _productRepository.Add(product);

            await _productRepository.SaveChanges(cancellationToken);

            return await Task.FromResult(true);
        }
    }

}
