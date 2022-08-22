using BikeStore.Models;
using System.Collections.Generic;

namespace InfoViewer.Models
{
	public abstract class ViewModelBase
	{
		public PageInfo PageInfo { get; set; }
		public AppOptions Options { get; set; }
	}
}