using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.Domain.Product.Commands;

namespace ProductInventory.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ProductResult>))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllProducts());

            return Ok(result);
        }

        [Route("{id:int}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResult))]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetProduct(id));

            return Ok(result);
        }

        [Route("")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProduct product)
        {
            var result = await _mediator.Send(product);

            return Ok(result);
        }

        [Route("{id:int}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateProduct product)
        {
            var result = await _mediator.Send(product);

            return Ok(result);
        }
    }
}
