using BikeStore.Models;

namespace InfoViewer.Models
{
	public class OrderViewModel : BaseViewModel
	{
		public OrderViewModel(string currentAction, string title) : base(currentAction, title)
		{
		}

		public Order Order { get; set; }
	}
}
