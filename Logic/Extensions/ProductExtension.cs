using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Extensions
{
	public static class ProductExtension
	{
		public static IEnumerable<Product> DefaultSorting(this IEnumerable<Product> toSort)
		{
			return toSort.OrderByDescending(t => t.EditDate).ThenByDescending(t => t.Grade);
		}
	}
}
