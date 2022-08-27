using System;

namespace InfoViewer.Models
{
	public class PageInfo
	{
		public PageInfo(int pageNumber, int totalItems, int pageSize)
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
}
