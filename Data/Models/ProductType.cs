using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
	public class ProductType : BaseModel
	{
		[MaxLength(140)]
		public string Name { get; set; }
	}
}
