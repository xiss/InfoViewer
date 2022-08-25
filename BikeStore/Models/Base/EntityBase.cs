using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models.Base
{
	public abstract class EntityBase
	{
		[Display(Name = "Id")]
		public int Id { get; set; }
	}
}