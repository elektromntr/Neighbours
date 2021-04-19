using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
	public class Product : BaseModel
	{
		[MaxLength(140)]
		public string Name { get; set; }
		public ProductType Type { get; set; }
	}
}
