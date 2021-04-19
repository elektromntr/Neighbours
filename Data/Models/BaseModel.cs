using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
	public abstract class BaseModel
	{
		public Guid Id { get; set; }
		public virtual DateTime CreationDate { get; set; }
		public virtual DateTime EditDate { get; set; }
		[DefaultValue(false)]
		public virtual bool Archive { get; set; }
		[DefaultValue(false)]
		public virtual bool Deleted { get; set; }
		[Range(0, 999)]
		public int Grade { get; set; }
	}
}
