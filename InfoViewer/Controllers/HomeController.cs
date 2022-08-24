﻿using BikeStore.Repos;
using BikeStore.Models;
using InfoViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Linq;

namespace InfoViewer.Controllers
{
	public class OrdersController : Controller
	{
		private readonly OrderRepo _orderRepo;
		private readonly AppOptions _appOptions;

		public OrdersController(OrderRepo orderRepo, IOptions<AppOptions> options)
		{
			_orderRepo = orderRepo;
			_appOptions = options.Value;
		}
		[HttpGet]
		public async Task<IActionResult> Index(int page = 1, string sortOrder = null, string filter = null)
		{
			int _pageSize = _appOptions.PageSize;
			int _pageStart = (page - 1) * _pageSize;
			OrdersViewModel viewModel = new OrdersViewModel();

			string[] filters = filter?.Split(' ');

			// Это нормально исользовать одновременно а OrdersViewModel и ViewData или нужно
			// создавать свойства в OrdersViewModel?
			viewModel.CurrentOrder = sortOrder;
			viewModel.CurrentFilter = filter;

			viewModel.IdSortParam = string.IsNullOrEmpty(sortOrder) ? "IdDecs" : "";
			viewModel.NameSortParam = sortOrder == "Name" ? "NameDecs" : "Name";
			viewModel.DateSortParam = sortOrder == "Date" ? "DateDecs" : "Date";

			switch (sortOrder)
			{
				case "IdDecs":
					viewModel.Orders = await _orderRepo.GetRange(o => o.Id, o => o.CheckFilter(filters), _pageStart, _pageSize, false);
					break;

				case "Name":
					viewModel.Orders = await _orderRepo.GetRange(o => o.Customer.FullName, o => o.CheckFilter(filters), _pageStart, _pageSize);
					break;

				case "NameDecs":
					viewModel.Orders = await _orderRepo.GetRange(o => o.Customer.FullName, o => o.CheckFilter(filters), _pageStart, _pageSize, false);
					break;

				case "Date":
					viewModel.Orders = await _orderRepo.GetRange(o => o.OrderDate, o => o.CheckFilter(filters), _pageStart, _pageSize);
					break;

				case "DateDecs":
					viewModel.Orders = await _orderRepo.GetRange(o => o.OrderDate, o => o.CheckFilter(filters), _pageStart, _pageSize, false);
					break;

				default:
					viewModel.Orders = await _orderRepo.GetRange(o => o.Id, o => o.CheckFilter(filters), _pageStart, _pageSize);
					break;
			}

			viewModel.PageInfo = new PageInfo(page, _orderRepo.CountRange, _appOptions.PageSize);

			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Order(int id)
		{
			Order order = await _orderRepo.GetOne(id);
			if(order == null)
				return NotFound();
			order.OrderItems = order.OrderItems.OrderBy(i => i.Product.Name).ToList();
			return View(order);
		}
	}
}