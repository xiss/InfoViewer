using BikeStore.Models;
using System;
using System.Collections.Generic;

namespace InfoViewer.Models
{
	public class PageInfo
	{
		public PageInfo(int pageNumber, int totalItems, int pageSize = 20)
		{
			PageNumber = pageNumber;
			PageSize = pageSize;
			TotalItems = totalItems;
		}

		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public int TotalItems { get; set; }
		public int TotalPages { get => (int)Math.Ceiling((decimal)TotalItems / PageSize); }
	}

	public class IndexViewModel<T>
	{
		public IndexViewModel(IEnumerable<T> orders, PageInfo pageInfo)
		{
			Orders = orders;
			PageInfo = pageInfo;
		}

		public IEnumerable<T> Orders { get; set; }
		public PageInfo PageInfo { get; set; }
	}
}
