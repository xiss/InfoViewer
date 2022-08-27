using System.Collections.Generic;
using BikeStore.Models;

namespace InfoViewer.Models
{
	public class OrdersViewModel : BaseViewModel
	{
		public OrdersViewModel(string currentAction, string title) : base(currentAction, title)
		{
		}

		public string IdSortParam { get; set; }
		public string NameSortParam { get; set; }
		public string DateSortParam { get; set; }
		public IEnumerable<Order> Orders { get; set; }
	}
}
