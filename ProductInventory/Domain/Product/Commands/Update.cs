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
    public class UpdateProduct : IRequest<bool>
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public int CategoryId { get; set; }
        [DataMember] public string Image { get; set; }

        public UpdateProduct(string name, string description, int categoryId, string image)
        {
            Id = Id;
            Name =  name;
            Description = description;
            CategoryId = categoryId;
            Image = image;
        }
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProduct, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetById(request.Id);
            product.Update(request.Name, request.Description, request.CategoryId, request.Image);
            _productRepository.Update(product);
            await _productRepository.SaveChanges(cancellationToken);

            return await Task.FromResult(true);
        }
    }
}
