using BikeStore.Models;
using System.Collections.Generic;

namespace InfoViewer.Models
{
	public abstract class BaseViewModel
	{
		protected BaseViewModel(string currentAction, string title)
		{
			CurrentAction = currentAction;
			Title = title;
		}

		public string CurrentOrder { get; set; }
		public string CurrentFilter { get; set; }
		public string CurrentAction { get; set; }
		public string Title { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}