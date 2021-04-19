using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
	public interface IProductService
	{
		/// <summary>
		/// Return collection od Products
		/// </summary>
		/// <param name="expression">Filter for products</param>
		/// <returns>Enumerable of Products</returns>
		Task<IEnumerable<Product>> GetMany(Func<Product, bool> expression);
		/// <summary>
		/// One product selected by id
		/// </summary>
		/// <param name="id">Guid</param>
		/// <returns>One product</returns>
		Task<Product> GetOne(Guid id);
		/// <summary>
		/// Creates new Product and return created object
		/// </summary>
		/// <param name="product">Object to create</param>
		/// <returns>Created one object</returns>
		Task<Product> Create(Product product);
		/// <summary>
		/// Removes entity from repository
		/// </summary>
		/// <param name="id">Id of entity</param>
		Task Delete(Guid id);
	}
}
