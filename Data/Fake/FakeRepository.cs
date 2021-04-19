using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Fake
{
	public class FakeRepository
	{
		public FakeRepository()
		{
		}

		public virtual IList<Product> GetProducts()
		{
			return
			new List<Product>
			{
				new Product
				{
					Id = Guid.NewGuid(),
					Name = "Chris",
					Type = GetTypes().FirstOrDefault()
				},
				new Product
				{
					Id = Guid.NewGuid(),
					Name = "Marianne",
					Type = GetTypes().LastOrDefault()
				}
			};
		}

		private IList<ProductType> GetTypes()
		{
			return
			new List<ProductType>
			{
				new ProductType
				{
					Id = Guid.NewGuid(),
					Name = "Bread",
				},
				new ProductType
				{
					Id = Guid.NewGuid(),
					Name = "Roll",
				}
			};
		}

		public virtual Product Add(Product product)
		{
			var repo = GetProducts();
			repo.Add(product);
			return repo.FirstOrDefault(r => r.Id.Equals(product.Id));
		}

		public virtual void Delete(Guid id)
		{
			var repo = GetProducts();
			var entity = repo.FirstOrDefault(p => p.Id.Equals(id));
			repo.Remove(entity);
		}
	}
}
