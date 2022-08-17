using BikeStore.Models;

namespace BikeStore.Repos
{
	public class OrderItemRepo : BaseRepo<OrderItem>
	{
		public OrderItemRepo(Context context) : base(context)
		{
		}
	}
}
