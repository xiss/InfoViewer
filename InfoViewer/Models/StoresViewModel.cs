using BikeStore.Models;
using System.Collections.Generic;

namespace InfoViewer.Models
{
	public class StoresViewModel : BaseViewModel
	{
		public StoresViewModel(string currentAction, string title) : base(currentAction, title)
		{
		}
		public IEnumerable<Store> Stores;
	}
}
