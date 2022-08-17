using BikeStore.Models;

namespace BikeStore.Repos
{
	public class StoreRepo : BaseRepo<Store>
	{
		public StoreRepo(Context context) : base(context)
		{
		}
	}
}
