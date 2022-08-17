using BikeStore.Models;

namespace BikeStore.Repos
{
	public class CategoryRepo : BaseRepo<Category>
	{
		public CategoryRepo(Context context) : base(context)
		{
		}
	}
}
