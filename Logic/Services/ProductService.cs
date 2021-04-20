using Data.Fake;
using Data.Models;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Logic.Extensions;
using System.Threading.Tasks;

namespace Logic.Services
{
	public class ProductService : IProductService
	{
		private FakeRepository _fakeRepo;

		public ProductService(FakeRepository fakeRepo)
		{
			_fakeRepo = fakeRepo;
		}

		public async Task<IEnumerable<Product>> GetMany(Func<Product, bool> expression) =>
			_fakeRepo.GetProducts()
				.Where(expression)
				.DefaultSorting();

		public async Task<Product> GetOne(Guid id)
		{
			return _fakeRepo.GetProducts()
				.FirstOrDefault(p => p.Id.Equals(id));
		}

		public async Task<Product> Create(Product product)
		{
			product.Id = Guid.NewGuid();
			product.CreationDate = DateTime.Now; 
			product.EditDate = DateTime.Now;
			var result = _fakeRepo.Add(product);
			return result;
		}

		public async Task Delete(Guid id)
		{
			_fakeRepo.Delete(id);
		}
	}
}
