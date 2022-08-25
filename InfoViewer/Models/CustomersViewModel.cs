using System.Collections.Generic;
using BikeStore.Models;
using System.ComponentModel.DataAnnotations;

namespace InfoViewer.Models
{
	public class CustomersViewModel : BaseViewModel
	{
		public string IdSortParam { get; set; }
		public string NameSortParam { get; set; }
		public string LastNameSortParam { get; set; }
		public string EmailSortParam { get; set; }
		public string PhoneSortParam { get; set; }
		public IEnumerable<Customer> Customers { get; set; }
	}

	public class CustomerViewModel
	{
		public Customer Customer { get; set; }
		[Display(Name = "Amount Ordered ($)")]
		public decimal AmountOrdered { get; set; }
		public List<Order> Orders { get; set; }
	}
}