using InfoViewer.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoViewer.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult About()
		{
			AboutViewModel viewModel = new AboutViewModel(nameof(About), "About");
			viewModel.Text = @"<h4>Educational application InfoViewer BackEnd</h4><p>Technologies used:</p><ul><li>EFCore 5.0.17</li><li>ASPNET.Core 3.1.10</li>
							<li>Bootstrap v5.1.3</li><li>CanvasJS HTML5 & JavaScript Charts - v3.6.7 GA</li></ul>
							<p>Source of Data: <a href='https://www.sqlservertutorial.net/sql-server-sample-database/'>SQL Server Sample Database</a></p>";
			return View(viewModel);
		}
	}
}
