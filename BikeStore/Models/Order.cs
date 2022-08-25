using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
		[Display(Name = "Customer id")]
		public int CustomerId { get; set; }
		public virtual Customer Customer { get; set; }
		[Display(Name = "Order status")]
		public byte OrderStatus { get; set; }
		[Display(Name = "Order date")]
		public DateTime OrderDate { get; set; }
		[Display(Name = "Required date")]
		public DateTime RequiredDate { get; set; }
		[Display(Name = "Shipped date")]
		public DateTime? ShippedDate { get; set; }
		[Display(Name = "Store id")]
		public int StoreId { get; set; }
		public virtual Store Store { get; set; }
		[Display(Name = "Stuff id")]
		public int? StuffId { get; set; }
		public virtual Staff? Stuff { get; set; }
		public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
		[NotMapped]
		[Display(Name = "Amount")]
		public decimal Amount => OrderItems.Sum(o => o.ListPrice * o.Quantity);

		public bool CheckFilter(string[] filters = null)
		{
			if (filters == null) return true;
			foreach (var filter in filters)
			{
				if (Id.ToString() == filter) return true;
				if (Customer.FirstName.Contains(filter, StringComparison.OrdinalIgnoreCase)) return true;
				if (Customer.LastName.Contains(filter, StringComparison.OrdinalIgnoreCase)) return true;
			}
			return false;
		}
	}
}
