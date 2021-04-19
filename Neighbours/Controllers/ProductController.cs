using Data.Models;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _productService.GetMany(p => !p.Deleted);
		}

		[HttpGet]
		[Route("GetOne/{id:Guid}")]
		public async Task<Product> GetOne(Guid id)
		{
			return await _productService.GetOne(id);
		}
	}
}
