using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace InfoViewer.Helpers
{
	public static class FilterHelper
	{
		public static HtmlString CreateFilter(this IHtmlHelper html, string urlForReset, string actionForForm, string labelText, string currentFilter,
			Dictionary<string, string> pageParams = null)
		{
			//form
			TagBuilder form = new TagBuilder("form");
			form.MergeAttribute("method", "get");
			form.MergeAttribute("role", "search");
			form.MergeAttribute("action", actionForForm);

			//div outer
			TagBuilder divOuter = GetNewDiv("mb-3 row");

			//label
			TagBuilder divInner = GetNewDiv("col-auto");
			TagBuilder label = new TagBuilder("label");
			label.MergeAttribute("for", "Filter");
			label.AddCssClass("col-form-label");
			label.InnerHtml.Append(labelText);
			divInner.InnerHtml.AppendHtml(label);
			divOuter.InnerHtml.AppendHtml(divInner);

			//input
			divInner = GetNewDiv("col-auto");
			TagBuilder input = new TagBuilder("input");
			input.AddCssClass("form-control");
			input.MergeAttribute("type", "search");
			input.MergeAttribute("name", "Filter");
			input.MergeAttribute("placeholder", "Filter...");
			input.MergeAttribute("value", currentFilter);
			divInner.InnerHtml.AppendHtml(input);
			divOuter.InnerHtml.AppendHtml(divInner);

			//hidden inputs (pageParams)
			if (pageParams != null)
				foreach (var item in pageParams)
				{
					divOuter.InnerHtml.AppendHtml(GetHiddenInput(item.Key, item.Value));
				}

			//button filter
			divInner = GetNewDiv("col-auto");
			TagBuilder button = new TagBuilder("button");
			button.AddCssClass("btn btn-primary");
			button.MergeAttribute("type", "submit");
			button.InnerHtml.Append("Filter");
			divInner.InnerHtml.AppendHtml(button);
			divOuter.InnerHtml.AppendHtml(divInner);

			//link to reset
			divInner = GetNewDiv("col-auto");
			TagBuilder a = new TagBuilder("a");
			a.AddCssClass("btn btn-secondary");
			a.MergeAttribute("href", urlForReset);
			a.InnerHtml.Append("Reset");
			divInner.InnerHtml.AppendHtml(a);
			divOuter.InnerHtml.AppendHtml(divInner);

			form.InnerHtml.AppendHtml(divOuter);

			var writer = new System.IO.StringWriter();
			form.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

			return new HtmlString(writer.ToString());
		}

		private static TagBuilder GetNewDiv(string cssClass)
		{
			TagBuilder div = new TagBuilder("div");
			div.AddCssClass(cssClass);
			return div;
		}

		private static TagBuilder GetHiddenInput(string name, string value)
		{
			TagBuilder input = new TagBuilder("input");
			input.MergeAttribute("type", "hidden");
			input.MergeAttribute("name", name);
			input.MergeAttribute("value", value);
			return input;
		}
	}
}
