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

		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		public int ItemId { get; set; }
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		public int Quantity { get; set; }
		public decimal ListPrice { get; set; }
		public decimal Discount { get; set; }
	}
}
