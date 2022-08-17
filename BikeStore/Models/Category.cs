using System.Collections.Generic;

namespace BikeStore.Models
{
	public class Category : Base.EntityBase
	{
		public Category(string name, int id )
		{
			Name = name;
			Id = id;
		}

		public string Name { get; set; }
		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
