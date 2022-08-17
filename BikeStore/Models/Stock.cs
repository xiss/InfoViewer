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

		public int StoreId { get; set; }
		public virtual Store Store { get; set; }
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		public int Quantity { get; set; }
	}
}