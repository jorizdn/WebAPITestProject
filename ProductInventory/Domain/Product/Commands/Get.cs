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
    public class GetProduct : IRequest<ProductResult>
    {
        [DataMember]
        public int Id { get; private set; }

        public GetProduct(int id)
        {
            Id = id;
        }
    }

    public class GetProductHandler : IRequestHandler<GetProduct, ProductResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<ProductResult> Handle(GetProduct request, CancellationToken cancellationToken)
        {
            var result =  _productRepository.GetById(request.Id);  
            var product = new ProductResult()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Image = result.Image
            };

            return Task.FromResult(product);
        }
    }

    public class ProductResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
