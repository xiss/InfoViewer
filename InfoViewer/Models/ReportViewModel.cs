using Microsoft.AspNetCore.Html;
using System.Collections.Generic;

namespace InfoViewer.Models
{
	public class ReportViewModel : BaseViewModel
	{
		public ReportViewModel(string currentAction, string title) : base(currentAction, title)
		{
		}
		public Dictionary<string, string> ChartsJsonDatas { get; set; } = new Dictionary<string, string>();
	}
}