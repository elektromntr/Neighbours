using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Fake;
using Data.Models;
using Logic.Services;
using Logic.Services.Interfaces;
using Moq;
using Xunit;

namespace Tests.Logic
{
	public class ProductTests
	{
		private IProductService _sut;
		private Guid _testGuid;
		private Mock<FakeRepository> fakeRepoMoq;

		public ProductTests()
		{
			_testGuid = Guid.NewGuid();
			fakeRepoMoq = new Mock<FakeRepository>();
		}

		[Fact]
		public async Task ProductService_Exists()
		{
			//Act
			_sut = new ProductService(null);

			//Assert
			Assert.NotNull(_sut);
		}

		[Fact]
		public async Task GetMany_ReturnsListOfProducts()
		{
			//Arrange
			Func<Product, bool> expression = s => !s.Deleted;
			_sut = new ProductService(fakeRepoMoq.Object);

			//Act
			var result = await _sut.GetMany(expression);

			//Assert
			Assert.NotNull(result);
			Assert.IsAssignableFrom<IEnumerable<Product>>(result);
		}

		[Fact]
		public async Task GetOne_ReturnsOneProduct()
		{
			//Arrange
			fakeRepoMoq.Setup(r => r.GetProducts())
				.Returns(new List<Product>
				{
					new Product
					{
						Id = _testGuid,
						Name = "Test product",
					}
				});
			_sut = new ProductService(fakeRepoMoq.Object);

			//Act
			Product result = await _sut.GetOne(_testGuid);

			//Assert
			Assert.NotNull(result);
			Assert.IsType<Product>(result);
			Assert.Equal(_testGuid, result.Id);
		}

		[Fact]
		public async Task Create_ReturnsCreatedProduct()
		{
			//Arrange
			fakeRepoMoq.Setup(r => r.Add(It.IsAny<Product>()))
				.Returns(
					new Product
					{
						Id = _testGuid,
						Name = "Created product",
					}
				);
			_sut = new ProductService(fakeRepoMoq.Object);

			//Act
			Product result = await _sut.Create(new Product
			{
				Id = _testGuid,
				Name = "Created product"
			});

			//Assert
			Assert.NotNull(result);
			Assert.IsType<Product>(result);
			Assert.Equal(_testGuid, result.Id);
		}

		[Fact]
		public async Task Create_CreatedProductHasIdWithProperGuid()
		{
			//Arrange
			var product = new Product
			{
				Name = "Test"
			};
			fakeRepoMoq.Setup(r => r.Add(It.IsAny<Product>()))
				.Returns(product);
			_sut = new ProductService(fakeRepoMoq.Object);

			//Act
			Product result = await _sut.Create(product);

			//Assert
			Assert.NotNull(result);
			Assert.IsType<Product>(result);
			Assert.NotEqual(Guid.Empty, result.Id);
		}

		[Fact]
		public async Task Delete_RemovesProduct()
		{
			//Arrange
			fakeRepoMoq.Setup(r => r.Delete(It.IsAny<Guid>()));
			_sut = new ProductService(fakeRepoMoq.Object);

			//Act
			await _sut.Delete(_testGuid);

			//Assert
			fakeRepoMoq.Verify(r => r.Delete(_testGuid), Times.Exactly(1));
		}
	}
}
