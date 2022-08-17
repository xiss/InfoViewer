using System.Collections.Generic;
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

		public string Name { get; set; }
		public int BrandId { get; set; }
		public virtual Brand Brand { get; set; }  
		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
		public short ModelYear { get; set; }
		public decimal ListPrice { get; set; }
		public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
		public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	}
}
