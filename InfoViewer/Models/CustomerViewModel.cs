using System.Collections.Generic;
using BikeStore.Models;
using System.ComponentModel.DataAnnotations;

namespace InfoViewer.Models
{
	public class CustomerViewModel : BaseViewModel
	{
		public CustomerViewModel(string currentAction, string title) : base(currentAction, title)
		{
		}

		public Customer Customer { get; set; }
		[Display(Name = "Amount Ordered ($)")]
		public decimal AmountOrdered { get; set; }
		public List<Order> Orders { get; set; }
	}
}