using BikeStore.Models;

namespace BikeStore.Repos
{
	public class StockRepo : BaseRepo<Stock>
	{
		public StockRepo(Context context) : base(context)
		{
		}
	}
}
