using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Models;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Neighbours.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly ILogger<Product> _logger;
		private readonly IProductService _productService;

		public ProductController(ILogger<Product> logger,
			IProductService productService)
		{
			_logger = logger;
			_productService = productService;
		}

		[HttpGet]
		[Route("All")]
		public async Task<ActionResult<IEnumerable<Product>>> GetAll()
		{
            var result = await _productService.GetMany(p => !p.Deleted);
			if (result is null) return NotFound();
            return Ok(result);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<ActionResult<Product>> GetOne(Guid id)
		{
            var result = await _productService.GetOne(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

		[HttpPost]
		public async Task<ActionResult<Product>> Create(Product product)
		{
			var result = await _productService.Create(product);
			return CreatedAtAction(nameof(GetOne), new { id = result.Id } , result);
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _productService.Delete(id);
			return NoContent();
		}
	}
}
