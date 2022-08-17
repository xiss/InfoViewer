using BikeStore.Models;

namespace BikeStore.Repos
{
	public class StuffRepo : BaseRepo<Staff>
	{
		public StuffRepo(Context context) : base(context)
		{
		}
	}
}
