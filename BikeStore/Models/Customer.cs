using BikeStore.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace BikeStore.Models
{
	public class Customer : PersonBase
	{
		public Customer(int id, string street, string city, string state, string zipCode, string firstName, string lastName, string email, string phone)
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
		[Display(Name = "Street")]
		public string Street { get; set; }
		[Display(Name = "City")]
		public string City { get; set; }
		[Display(Name = "State")]
		public string State { get; set; }
		[Display(Name = "ZipCode")]
		public string ZipCode { get; set; }
		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

		// Стоит писать это в модель?
		public bool CheckFilter(string[] filters = null)
		{
			if (filters == null) return true;
			foreach (var filter in filters)
			{
				if (Id.ToString() == filter) return true;
				if (Street.Contains(filter, StringComparison.OrdinalIgnoreCase)) return true;
				if (City.Contains(filter, StringComparison.OrdinalIgnoreCase)) return true;
				if (State.Contains(filter, StringComparison.OrdinalIgnoreCase)) return true;
				if (ZipCode == filter) return true;
				if (FirstName.Contains(filter, StringComparison.OrdinalIgnoreCase)) return true;
				if (LastName.Contains(filter, StringComparison.OrdinalIgnoreCase)) return true;
				if (Email.Contains(filter, StringComparison.OrdinalIgnoreCase)) return true;
				if (Phone == filter) return true;
			}
			return false;
		}
	}
}