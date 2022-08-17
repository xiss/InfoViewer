using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.Models.Base
{
	public abstract class PersonBase : EntityBase
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		[NotMapped]
		public string FullName { get => FirstName + " " + LastName; }
	}
}