using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;

namespace Data.Fake
{
	public class FakeRepository
	{
        private IList<Product> _products;
        
		public FakeRepository()
		{
			_products = new List<Product>
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

		public virtual IEnumerable<Product> GetProducts() =>
             _products;

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
			_products.Add(product);
			var res = _products.FirstOrDefault(r => r.Id.Equals(product.Id));
			return res;
		}

		public virtual void Delete(Guid id)
		{
			var entity = _products.FirstOrDefault(p => p.Id.Equals(id));
			_products.Remove(entity);
		}
	}
}
