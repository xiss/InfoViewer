using System.Collections.Generic;
using BikeStore.Models;

namespace InfoViewer.Models
{
	public class OrdersViewModel : ViewModelBase
	{
		public OrdersViewModel(AppOptions options)
		{
			Options = options;
		}

		public string CurrentOrder { get; set; }
		public string CurrentFilter { get; set; }
		public string IdSortParam { get; set; }
		public string NameSortParam { get; set; }
		public string DateSortParam { get; set; }
		public IEnumerable<Order> Orders { get; set; }
	}
}
