using System;
using System.Collections.Generic;

namespace BikeStore.Models
{
	public class Order : Base.EntityBase
	{
		public Order(int id, int customerId, byte orderStatus, DateTime orderDate, DateTime requiredDate, DateTime? shippedDate, int storeId, int? stuffId)
		{
			Id = id;
			CustomerId = customerId;
			OrderStatus = orderStatus;
			OrderDate = orderDate;
			RequiredDate = requiredDate;
			ShippedDate = shippedDate;
			StoreId = storeId;
			StuffId = stuffId;
		}

		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		public byte OrderStatus { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime RequiredDate { get; set; }
		public DateTime? ShippedDate { get; set; }
		public int StoreId { get; set; }
		public virtual Store Store { get; set; }
		public int? StuffId { get; set; }
		public virtual Staff? Stuff { get; set; }
		public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

		public bool CheckFilter(string[] filters = null)
		{
			if (filters == null) return true;
			foreach (var filter in filters)
			{
				if (Id.ToString() == filter) return true;
				if (Customer.FirstName == filter) return true;
				if (Customer.LastName == filter) return true;
			}
			return false;
		}
	}
}
