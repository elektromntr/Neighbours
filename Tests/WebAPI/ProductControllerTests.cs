using Xunit;
using System.Threading.Tasks;
using Neighbours.Controllers;
using Logic.Services;
using Logic.Services.Interfaces;
using Moq;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace Tests.WebAPI
{
	public class ProductControllerTests
	{
		private ProductController _sut;
		private Mock<IProductService> _productServiceMoq;

		public ProductControllerTests()
		{
			_productServiceMoq = new Mock<IProductService>();
		}

		[Fact]
		public async Task ProductController_Exists()
		{
			//Arrange
			//Act
			_sut = new ProductController(null, null);

			//Assert
			Assert.NotNull(_sut);
		}

		[Fact]
		public async Task GetAll_ReturnsOkObjectWithListOfProducts()
		{
			//Arrange
			var list = new List<Product>
			{
				new Product
				{
					Name = "Test"
				}
			};
			Func<Product, bool> expression = s => !s.Deleted;
			_productServiceMoq.Setup(s => s.GetMany(It.IsAny<Func<Product, bool>>()))
				.ReturnsAsync(list);
			_sut = new ProductController(null, _productServiceMoq.Object);

			//Act
			var result = await _sut.GetAll();

			//Assert
			Assert.NotNull(result);
			Assert.IsType<OkObjectResult>(result.Result);
			Assert.IsAssignableFrom<ActionResult<IEnumerable<Product>>>(result);
		}
	}
}
