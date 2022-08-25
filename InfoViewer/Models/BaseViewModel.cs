using BikeStore.Models;
using System.Collections.Generic;

namespace InfoViewer.Models
{
	public abstract class BaseViewModel
	{
		public string CurrentOrder { get; set; }
		public string CurrentFilter { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}