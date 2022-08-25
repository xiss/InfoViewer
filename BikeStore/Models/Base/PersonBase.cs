using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeStore.Models.Base
{
	public abstract class PersonBase : EntityBase
	{
		[Display(Name = "First name")]
		public string FirstName { get; set; }
		[Display(Name = "Last name")]
		public string LastName { get; set; }
		[Display(Name = "Phone")]
		public string Phone { get; set; }
		[Display(Name = "Email")]
		public string Email { get; set; }

		[NotMapped]
		[Display(Name = "Name")]
		public string FullName { get => FirstName + " " + LastName; }
	}
}