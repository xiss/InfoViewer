using System.Collections.Generic;
using BikeStore.Models;

namespace InfoViewer.Models
{
	public class CustomersViewModel : BaseViewModel
	{
		public CustomersViewModel(string currentAction, string title) : base(currentAction, title)
		{
		}

		public string IdSortParam { get; set; }
		public string NameSortParam { get; set; }
		public string LastNameSortParam { get; set; }
		public string EmailSortParam { get; set; }
		public string PhoneSortParam { get; set; }
		public IEnumerable<Customer> Customers { get; set; }
	}
}