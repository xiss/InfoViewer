using BikeStore.Models;

namespace BikeStore.Repos
{
	public class OrderRepo : BaseRepo<Order>
	{
		public OrderRepo(Context context) : base(context)
		{
		}
	}
}
