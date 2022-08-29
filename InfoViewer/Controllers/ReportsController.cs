using Microsoft.AspNetCore.Mvc;
using InfoViewer.Models;
using BikeStore.Repos;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Html;
using System;
using System.Globalization;

namespace InfoViewer.Controllers
{
	public class ReportsController : Controller
	{
		private AppOptions _appOptions;
		private OrderRepo _orderRepo;

		public ReportsController(IOptions<AppOptions> appOptions, OrderRepo orderRepo)
		{
			_appOptions = appOptions.Value;
			_orderRepo = orderRepo;
		}

		[HttpGet]
		public async Task<IActionResult> SalesByBrands()
		{
			ReportViewModel viewModel = new ReportViewModel(nameof(this.SalesByBrands), "Sales by brands");
			JsonSerializerOptions options = new JsonSerializerOptions();
			options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
			List<DataPoint> dataPoints = new List<DataPoint>();

			var dataSalesByBrands = await _orderRepo.GetSalesByBrand();
			foreach (var item in dataSalesByBrands)
			{
				dataPoints.Add(new DataPoint(item.Item1.Id, item.Item2, item.Item1.Name));
			}
			viewModel.ChartsJsonDatas.Add("salesByBrands", JsonSerializer.Serialize(dataPoints, options));

			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> SalesByStores()
		{
			ReportViewModel viewModel = new ReportViewModel(nameof(this.SalesByStores), "Sales by stores");
			JsonSerializerOptions options = new JsonSerializerOptions();
			options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

			var dataSalesByStore = await _orderRepo.GetSalesByStores();
			List<DataPoint> dataPoints = new List<DataPoint>();
			foreach (var item in dataSalesByStore)
			{
				dataPoints.Add(new DataPoint(item.Item1.Id, item.Item2, item.Item1.Name));
			}
			viewModel.ChartsJsonDatas.Add("salesByStores", JsonSerializer.Serialize(dataPoints, options));

			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> SalesByMonths()
		{
			ReportViewModel viewModel = new ReportViewModel(nameof(this.SalesByMonths), "Sales by months");
			JsonSerializerOptions options = new JsonSerializerOptions();
			options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
			List<DataPoint> dataPoints = new List<DataPoint>();

			var dataSalesByMonths = await _orderRepo.GetSalesByMonths();
			dataPoints.Clear();
			foreach (var item in dataSalesByMonths)
			{
				dataPoints.Add(new DataPoint(item.Item1, item.Item2, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Item1)));
			}
			viewModel.ChartsJsonDatas.Add("salesByMonths", JsonSerializer.Serialize(dataPoints, options));

			return View(viewModel);
		}

	}
}
