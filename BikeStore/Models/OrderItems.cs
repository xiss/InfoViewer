using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
	public class OrderItem
	{
		public OrderItem(int orderId, int itemId, int productId, int quantity, decimal listPrice, decimal discount)
		{
			OrderId = orderId;
			ItemId = itemId;
			ProductId = productId;
			Quantity = quantity;
			ListPrice = listPrice;
			Discount = discount;
		}
		[Display(Name = "Order id")]
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		[Display(Name = "Item id")]
		public int ItemId { get; set; }
		[Display(Name = "Product id")]
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		[Display(Name = "Quantity")]
		public int Quantity { get; set; }
		[Display(Name = "List price")]
		public decimal ListPrice { get; set; }
		[Display(Name = "Discount")]
		public decimal Discount { get; set; }
	}
}
