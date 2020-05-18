using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProductInventory.Infrastructure.Interface;

namespace ProductInventory.Domain.Product.Commands
{
    public class GetAllProducts : IRequest<List<ProductResult>>
    {
    }

    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, List<ProductResult>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<ProductResult>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var result = _productRepository.GetAll();
            var products = new List<ProductResult>();
            foreach (var product in result)
            {
                products.Add(new ProductResult()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image
                });
            }

            return Task.FromResult(products);
        }
    }
}
