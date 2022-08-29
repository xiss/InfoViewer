using BikeStore.Repos;
using InfoViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace InfoViewer.Controllers
{
	public class StoresController : Controller
	{
		private StoreRepo _storeRepo;
		private AppOptions _appOptions;

		public StoresController(StoreRepo storeRepo, IOptions<AppOptions> appOptions)
		{
			_storeRepo = storeRepo;
			_appOptions = appOptions.Value;
		}

		[HttpGet]
		public async Task<IActionResult> Stores()
		{
			StoresViewModel viewModel = new StoresViewModel(nameof(this.Stores), "Stores");
			viewModel.Stores = await _storeRepo.GetAll(s => s.Id);

			return View(viewModel);
		}
	}
}