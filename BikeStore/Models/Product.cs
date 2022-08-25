using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
	public class Product : Base.EntityBase
	{
		public Product(int id, string name, int brandId, int categoryId, short modelYear, decimal listPrice)
		{
			Id = id;
			Name = name;
			BrandId = brandId;
			CategoryId = categoryId;
			ModelYear = modelYear;
			ListPrice = listPrice;
		}
		[Display(Name = "Name")]
		public string Name { get; set; }
		[Display(Name = "Brand id")]
		public int BrandId { get; set; }
		public virtual Brand Brand { get; set; }
		[Display(Name = "Category id")]
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
		[Display(Name = "Model year")]
		public short ModelYear { get; set; }
		[Display(Name = "List price")]
		public decimal ListPrice { get; set; }
		public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
		public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
