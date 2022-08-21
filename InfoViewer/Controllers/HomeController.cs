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

		public IActionResult Index(int page = 1, string sortOrder = null, string filter = null)
		{
			//TODO В конфиг
			int _pageSize = 20;
			int _pageStart = (page - 1) * _pageSize;
			OrdersViewModel viewModel = new OrdersViewModel();

			string[] filters = filter?.Split(' ');

			// Это нормально исользовать одновременно а OrdersViewModel и ViewData или нужно создавать свойства в OrdersViewModel?
			viewModel.CurrentOrder = sortOrder;
			viewModel.CurrentFilter = filter;

			viewModel.IdSortParam = string.IsNullOrEmpty(sortOrder) ? "IdDecs" : "";
			viewModel.NameSortParam = sortOrder == "Name" ? "NameDecs" : "Name";
			viewModel.DateSortParam = sortOrder == "Date" ? "DateDecs" : "Date";

			switch (sortOrder)
			{
				case "IdDecs":
					viewModel.Orders = _orderRepo.GetRange(o => o.Id, o => o.CheckFilter(filters), _pageStart, _pageSize, false);
					break;
				case "Name":
					viewModel.Orders = _orderRepo.GetRange(o => o.Customer.FullName, o => o.CheckFilter(filters), _pageStart, _pageSize);
					break;
				case "NameDecs":
					viewModel.Orders = _orderRepo.GetRange(o => o.Customer.FullName, o => o.CheckFilter(filters), _pageStart, _pageSize, false);
					break;
				case "Date":
					viewModel.Orders = _orderRepo.GetRange(o => o.OrderDate, o => o.CheckFilter(filters), _pageStart, _pageSize);
					break;
				case "DateDecs":
					viewModel.Orders = _orderRepo.GetRange(o => o.OrderDate, o => o.CheckFilter(filters), _pageStart, _pageSize, false);
					break;
				default:
					viewModel.Orders = _orderRepo.GetRange(o => o.Id, o => o.CheckFilter(filters), _pageStart, _pageSize);
					break;
			}

			

			viewModel.PageInfo = new PageInfo(page, _orderRepo.CountRange);

			return View(viewModel);
		}
	}
}
