using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.Models
{
	public class Store : Base.EntityBase
	{
		public Store(int id, string name, string phone, string email, string street, string city, string state, string zipCode)
		{
			Id = id;
			Name = name;
			Phone = phone;
			Email = email;
			Street = street;
			City = city;
			State = state;
			ZipCode = zipCode;
		}
		[Display(Name = "Shop")]
		public string Name { get; set; }
		[Display(Name = "Phone")]
		public string Phone { get; set; }
		[Display(Name = "Email")]
		public string Email { get; set; }
		[Display(Name = "Street")]
		public string Street { get; set; }
		[Display(Name = "City")]
		public string City { get; set; }
		[Display(Name = "State")]
		public string State { get; set; }
		[Display(Name = "ZipCode")]
		public string ZipCode { get; set; }
		public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
		public virtual ICollection<Staff> Stuffs { get; set; } = new List<Staff>();
	}
}
