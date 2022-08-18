using System.Collections.Generic;

namespace InfoViewer.Models
{
	public class ViewModel<T>
	{
		public ViewModel(IEnumerable<T> orders, PageInfo pageInfo)
		{
			Orders = orders;
			PageInfo = pageInfo;
		}

		public IEnumerable<T> Orders { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}
