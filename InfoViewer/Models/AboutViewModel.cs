namespace InfoViewer.Models
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel(string currentAction, string title) : base(currentAction, title)
		{
		}
		public string Text { get; set; }
	}
}