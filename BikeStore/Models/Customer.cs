using BikeStore.Models.Base;
using System.Collections.Generic;

namespace BikeStore.Models
{
	public class Customer : PersonBase
	{
		public Customer(int id, string street, string city, string state, string zipCode,string firstName, string lastName, string email, string phone)
		{
			Id = id;
			Street = street;
			City = city;
			State = state;
			ZipCode = zipCode;
			FirstName = firstName;
			LastName = lastName;	
			Email = email;
			Phone = phone;
		}
				
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
	}

}
