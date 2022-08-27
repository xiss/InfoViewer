using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InfoViewer.TagHelpers
{
	[HtmlTargetElement(ParentTag = "li")]
	public class MenuItemTagHelper : TagHelper
	{
		public string Controller { get; set; }
		public string Action { get; set; } = "";
		public string CurentAction { get; set; }
		public string Class { get; set; }
		public string CurrentPageClass { get; set; }
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			string cls = Class;
			if (CurentAction == Action)
				cls += " " + CurrentPageClass;
			output.TagName = "a";

			output.Attributes.SetAttribute("class", cls);
			output.Attributes.SetAttribute("href", "/" + Controller + "/" + Action);
		}
	}
}