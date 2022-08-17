using BikeStore.Models;
using Microsoft.Data.SqlClient;
using BikeStore.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Repos
{
	public class BrandRepo : BaseRepo<Brand>
	{
		public BrandRepo(Context context) : base(context)
		{
		}	
	}
}
