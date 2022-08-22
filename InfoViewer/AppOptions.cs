namespace InfoViewer
{
	public class AppOptions
	{
		public const string App = "App";
		public int PageSize { get; set; } = 0;
		public int PaginationCount { get; set; } = 0;
		public string SampleDataPath { get; set; } = string.Empty;
		public bool SampleData { get; set; } = false;
	}
}
