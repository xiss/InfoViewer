using BikeStore.Repos;
using BikeStore.Models;
using InfoViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Linq;

namespace InfoViewer.Controllers
{
	public class CustomersController : Controller
	{
		private CustomerRepo _customerRepo { get; set; }
		private AppOptions _appOptions { get; set; }
		public CustomersController(CustomerRepo customerRepo, IOptions<AppOptions> appOptions)
		{
			_customerRepo = customerRepo;
			_appOptions = appOptions.Value;
		}
		[HttpGet]
		public async Task<IActionResult> Customers(int page = 1, string sortOrder = null, string filter = null)
		{
			int _pageSize = _appOptions.PageSize;
			int _pageStart = (page - 1) * _pageSize;
			CustomersViewModel viewModel = new CustomersViewModel(nameof(this.Customers), "Customers");

			string[] filters = filter?.Split(' ');

			//Sorting
			viewModel.CurrentOrder = sortOrder;
			viewModel.CurrentFilter = filter;

			viewModel.IdSortParam = string.IsNullOrEmpty(sortOrder) ? "IdDecs" : "";
			viewModel.NameSortParam = sortOrder == "Name" ? "NameDecs" : "Name";
			viewModel.EmailSortParam = sortOrder == "Email" ? "EmailDecs" : "Email";
			viewModel.PhoneSortParam = sortOrder == "Phone" ? "PhoneDecs" : "Phone";

			switch (sortOrder)
			{
				case "IdDecs":
					viewModel.Customers = await _customerRepo.GetRange(c => c.Id, c => c.CheckFilter(filters), _pageStart, _pageSize, false);
					break;
				case "Name":
					viewModel.Customers = await _customerRepo.GetRange(c => c.FullName, c => c.CheckFilter(filters), _pageStart, _pageSize);
					break;
				case "NameDecs":
					viewModel.Customers = await _customerRepo.GetRange(c => c.FullName, c => c.CheckFilter(filters), _pageStart, _pageSize, false);
					break;
				case "Email":
					viewModel.Customers = await _customerRepo.GetRange(c => c.Email, c => c.CheckFilter(filters), _pageStart, _pageSize);
					break;
				case "EmailDecs":
					viewModel.Customers = await _customerRepo.GetRange(c => c.Email, c => c.CheckFilter(filters), _pageStart, _pageSize, false);
					break;
				case "Phone":
					viewModel.Customers = await _customerRepo.GetRange(c => c.Phone, c => c.CheckFilter(filters), _pageStart, _pageSize);
					break;
				case "PhoneDecs":
					viewModel.Customers = await _customerRepo.GetRange(c => c.Phone, c => c.CheckFilter(filters), _pageStart, _pageSize, false);
					break;
				default:
					viewModel.Customers = await _customerRepo.GetRange(c => c.Id, c => c.CheckFilter(filters), _pageStart, _pageSize);
					break;
			}

			if (viewModel.Customers == null)
				return NotFound();

			viewModel.PageInfo = new PageInfo(page, _customerRepo.CountRange, _appOptions.PageSize);

			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Customer(int id)
		{
			Customer customer = await _customerRepo.GetOne(id);
			CustomerViewModel viewModel = new CustomerViewModel(nameof(this.Customer), "Customer " + customer.FullName);
			viewModel.Customer = customer;

			if (viewModel.Customer == null)
				return NotFound();

			viewModel.AmountOrdered = await _customerRepo.AmountOrdered(id);

			return View(viewModel);
		}
	}
}