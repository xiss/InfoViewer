using Microsoft.AspNetCore.Mvc;
using BikeStore.Repos;
using System.Collections.Generic;
using BikeStore.Models;
using InfoViewer.Models;

namespace InfoViewer.Controllers
{
	public class OrdersController : Controller
	{
		private readonly OrderRepo _orderRepo;
		public OrdersController(OrderRepo orderRepo)
		{
			_orderRepo = orderRepo;
		}

		public IActionResult Index(int page = 1)
		{
			int _pageSize = 20;
			List<Order> orders = _orderRepo.GetRange(o => o.Id, (page - 1) * _pageSize, _pageSize);
			PageInfo pageInfo = new PageInfo(page, _orderRepo.Count);
			ViewModel<Order> viewModel = new ViewModel<Order>(orders, pageInfo);

			return View(viewModel);
		}
	}
}
