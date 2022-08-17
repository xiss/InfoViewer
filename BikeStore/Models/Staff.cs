using BikeStore.Models.Base;
using System.Collections.Generic;

namespace BikeStore.Models
{
	public class Staff : PersonBase
	{
		public Staff(int id, byte active, int storeId, int? managerId, string firstName, string lastName, string email, string phone)
		{
			Id = id;
			Active = active;
			StoreId = storeId;
			ManagerId = managerId;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Phone = phone;
		}

		public byte Active { get; set; }
		public int StoreId { get; set; }
		public virtual Store Store { get; set; }
		public int? ManagerId { get; set; }
		public virtual Staff? Manager { get; set; }
		public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
		public virtual ICollection<Staff> Subordinates { get; set; } = new List<Staff>();
	}
}
