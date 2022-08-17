using BikeStore.Models;

namespace BikeStore.Repos
{
	public class CustomerRepo : BaseRepo<Customer>
	{
		public CustomerRepo(Context context) : base(context)
		{
		}
	}
}
