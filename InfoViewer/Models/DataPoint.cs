using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace InfoViewer.Models
{
	[DataContract]
	public class DataPoint
	{
		public DataPoint(double? x, double? y)
		{
			Y = y;
			X = x;
		}
		public DataPoint(double? x, decimal? y)
		{
			X = x;
			Y = Convert.ToDouble(y);
		}

		public DataPoint(double? x, decimal? y,  string label): this(x,y)
		{
			Label = label;
		}

		[JsonPropertyName("y")]
		public Nullable<double> Y { get; set; } = null;

		[JsonPropertyName("x")]
		public Nullable<double> X { get; set; } = null;

		[JsonPropertyName("label")]
		public string Label { get; set; } = null;
	}
}
