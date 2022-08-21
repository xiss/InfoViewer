using InfoViewer.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace InfoViewer.Helpers
{
	public static class PaginationHelper
	{
		public static HtmlString CreatePagination(this IHtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
		{
			//TODO В конфиг
			int linkCount = 6;
			// Если страница не первая, то начинаем с нескольких страниц назад
			int linkStart = pageInfo.PageNumber > 1 ? pageInfo.PageNumber - (int)Math.Ceiling(linkCount / (decimal)2) : 1;

			// Если получилась отрицательная страница, начинаем с первой
			if (linkStart < 1) linkStart = 1;

			// Если стартовая страница + количество ссылок больше общего количества страниц, берем общее количество страниц
			int linkEnd = linkStart + linkCount > pageInfo.TotalPages ? pageInfo.TotalPages : linkStart + linkCount;

			//ul
			TagBuilder ul = new TagBuilder("ul");
			ul.AddCssClass("pagination");

			//Previous
			ul = AddLi(ul, pageUrl, pageInfo.PageNumber - 1, pageInfo.PageNumber, linkEnd, "Previous");

			//li
			for (int page = linkStart; page <= linkEnd; page++)
			{
				ul = AddLi(ul, pageUrl, page, pageInfo.PageNumber, linkEnd, page.ToString());
			}

			//Next
			ul = AddLi(ul, pageUrl, pageInfo.PageNumber + 1, pageInfo.PageNumber, linkEnd, "Next");

			var writer = new System.IO.StringWriter();
			ul.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

			return new HtmlString(writer.ToString());
		}

		private static TagBuilder AddLi(TagBuilder ul, Func<int, string> pageUrl, int page, int curPage, int lastPage, string buttonName)
		{
			TagBuilder li = new TagBuilder("li");
			//Выделяем активную страницу
			if (page == curPage)
				li.AddCssClass("active");
			//Выключаем кнопки если  такой страницы нет
			if (page == 0 || page > lastPage)
				li.AddCssClass("disabled");

			li.AddCssClass("page-item");

			//a
			TagBuilder a = new TagBuilder("a");
			a.AddCssClass("page-link");
			a.MergeAttribute("href", pageUrl(page));
			a.InnerHtml.Append(buttonName);

			li.InnerHtml.AppendHtml(a);
			ul.InnerHtml.AppendHtml(li);
			return ul;
		}
	}
}
