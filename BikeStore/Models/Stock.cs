using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
	public class Stock
	{
		public Stock(int storeId, int productId, int quantity)
		{
			StoreId = storeId;
			ProductId = productId;
			Quantity = quantity;
		}
		[Display(Name = "Store id")]
		public int StoreId { get; set; }
		public virtual Store Store { get; set; }
		[Display(Name = "Product id")]
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		[Display(Name = "Quantity")]
		public int Quantity { get; set; }
	}
}