using System.Collections.Generic;

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

		public string Name { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
		public virtual ICollection<Staff> Stuffs { get; set; } = new List<Staff>();
	}
}
