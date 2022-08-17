using BikeStore.Models;

namespace BikeStore.Repos
{
	public class ProductRepo : BaseRepo<Product>
	{
		public ProductRepo(Context context) : base(context)
		{
		}
	}
}
