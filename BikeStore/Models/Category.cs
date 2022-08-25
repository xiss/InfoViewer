using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
	public class Category : Base.EntityBase
	{
		public Category(string name, int id )
		{
			Name = name;
			Id = id;
		}
		[Display(Name = "Name")]
		public string Name { get; set; }
		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
