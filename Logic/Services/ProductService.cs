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
			var repo = new List<Product>();
			repo.Add(product);
			return repo.FirstOrDefault(r => r.Id.Equals(product.Id));
		}

		public async Task Delete(Guid id)
		{
			_fakeRepo.Delete(id);
		}
	}
}
