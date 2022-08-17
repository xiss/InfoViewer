using System.Collections.Generic;
using System.Text;

namespace BikeStore.Models
{
	public class Brand : Base.EntityBase
	{
		public Brand(string name, int id)
		{
			Id = id;
			Name = name;
		}

		public string Name { get; set; }
		public virtual ICollection<Product> Products { get; set; } = new List<Product>();
	}
}
