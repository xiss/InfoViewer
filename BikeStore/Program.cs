using System;
using System.Globalization;
using BikeStore.Models;
using BikeStore.Models.Datalnitialize;

namespace BikeStore
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Context context = new Context();
			Datalnitializer datalnitializer = new Datalnitializer(context, @"E:\Dropbox\dev\ITVDN\InfoViewer (ASP.Net)\ExpData");
			datalnitializer.RecreateDatabase(); 
		}
	}
}
