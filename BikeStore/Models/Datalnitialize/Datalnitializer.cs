using BikeStore.Repos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace BikeStore.Models.Datalnitialize
{
	public class Datalnitializer
	{
		private readonly Context _context;
		private readonly BrandRepo _brandRepo;
		private readonly CategoryRepo _categoryRepo;
		private readonly CustomerRepo _customerRepo;
		private readonly OrderRepo _orderRepo;
		private readonly OrderItemRepo _orderItemRepo;
		private readonly ProductRepo _productRepo;
		private readonly StockRepo _stockRepo;
		private readonly StoreRepo _storeRepo;
		private readonly StuffRepo _staffRepo;
		private readonly string _pathToDataFolder;
		private IFormatProvider _fp = new NumberFormatInfo() { NumberDecimalSeparator = "." };

		public Datalnitializer(Context context, string pathToDataFolder)
		{
			_context = context;
			_brandRepo = new BrandRepo(context);
			_categoryRepo = new CategoryRepo(context);
			_customerRepo = new CustomerRepo(context);
			_orderItemRepo = new OrderItemRepo(context);
			_orderRepo = new OrderRepo(context);
			_productRepo = new ProductRepo(context);
			_stockRepo = new StockRepo(context);
			_storeRepo = new StoreRepo(context);
			_staffRepo = new StuffRepo(context);

			_pathToDataFolder = pathToDataFolder;
		}

		public void RecreateDatabase()
		{
			Debug.WriteLine("Попытка удалить БД: ");
			Debug.Write	( _context.Database.EnsureDeleted());

			Debug.WriteLine("Попытка содать БД: ");
			Debug.Write(_context.Database.EnsureCreated());

			Debug.WriteLine("Попытка Заполннить БД:");
			FillBrands("[brands].csv");
			FillCategories("[categories].csv");
			FillProducts("[products].csv");
			FillCustomers("[customers].csv");
			FillStores("[stores].csv");
			FillStaff("[staffs].csv");
			FillStocks("[stocks].csv");
			FillOrders("[orders].csv");
			FillOrderItems("[order_items].csv");

			Debug.WriteLine("БД заполнена");
		}

		private void FillBrands(string fileName)
		{
			List<Brand> brands = GetItems<Brand>(fileName, CreateBrand);
			_brandRepo.IdentityUpdatingOn();
			_brandRepo.Add(brands);
			_brandRepo.IdentityUpdatingOff();
		}

		private void FillCategories(string fileName)
		{
			List<Category> categories = GetItems<Category>(fileName, CreateCategory);
			_categoryRepo.IdentityUpdatingOn();
			_categoryRepo.Add(categories);
			_categoryRepo.IdentityUpdatingOff();
		}

		private void FillCustomers(string fileName)
		{
			List<Customer> customers = GetItems<Customer>(fileName, CreateCustomer);
			_customerRepo.IdentityUpdatingOn();
			_customerRepo.Add(customers);
			_customerRepo.IdentityUpdatingOff();
		}

		private void FillOrders(string fileName)
		{
			List<Order> orders = GetItems<Order>(fileName, CreateOrder);
			_orderRepo.IdentityUpdatingOn();
			_orderRepo.Add(orders);
			_orderRepo.IdentityUpdatingOff();
		}

		private void FillOrderItems(string fileName)
		{
			List<OrderItem> orderItems = GetItems<OrderItem>(fileName, CreateOrderItem);
			_orderItemRepo.Add(orderItems);
		}

		private void FillProducts(string fileName)
		{
			List<Product> products = GetItems<Product>(fileName, CreateProduct);
			_productRepo.IdentityUpdatingOn();
			_productRepo.Add(products);
			_productRepo.IdentityUpdatingOff();
		}

		private void FillStocks(string fileName)
		{
			List<Stock> stocks = GetItems<Stock>(fileName, CreateStock);
			_stockRepo.Add(stocks);
		}

		private void FillStores(string fileName)
		{
			List<Store> stores = GetItems<Store>(fileName, CreateStore);
			_storeRepo.IdentityUpdatingOn();
			_storeRepo.Add(stores);
			_storeRepo.IdentityUpdatingOff();
		}

		private void FillStaff(string fileName)
		{
			List<Staff> staff = GetItems<Staff>(fileName, CreateStaff);
			_staffRepo.IdentityUpdatingOn();
			_staffRepo.Add(staff);
			_staffRepo.IdentityUpdatingOff();
		}

		private List<T> GetItems<T>(string fileName, Func<string[], T> creator)
		{
			string[] lines = File.ReadAllLines(Path.Combine(_pathToDataFolder, fileName));
			List<T> list = new List<T>();
			for (int i = 1; i < lines.Length; i++)
			{
				string line = lines[i];
				string[] args = line.Split(';');
				try
				{
					list.Add(creator(args));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message + "ITEM: " + typeof(T) + ", INPUT: " + line);
				}
			}
			return list;
		}

		private Brand CreateBrand(string[] args)
		{
			return new Brand(args[1], int.Parse(args[0]));
		}

		private Category CreateCategory(string[] args)
		{
			return new Category(args[1], int.Parse(args[0]));
		}

		private Customer CreateCustomer(string[] args)
		{
			string phone = args[3] == "NULL" ? null : args[3];
			return new Customer(int.Parse(args[0]), args[5], args[6], args[7], args[8], args[1], args[2], args[4], phone);
		}

		private Order CreateOrder(string[] args)
		{
			DateTime? shippedDate = args[5] == "NULL" ? (DateTime?)null : DateTime.Parse(args[5]);
			return new Order(int.Parse(args[0]), int.Parse(args[1]), byte.Parse(args[2]), DateTime.Parse(args[3]), DateTime.Parse(args[4]),
				shippedDate, int.Parse(args[6]), int.Parse(args[7]));
		}

		private OrderItem CreateOrderItem(string[] args)
		{
			return new OrderItem(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]), int.Parse(args[3]), decimal.Parse(args[4], _fp), decimal.Parse(args[5], _fp));
		}

		private Product CreateProduct(string[] args)
		{
			return new Product(int.Parse(args[0]), args[1], int.Parse(args[2]), int.Parse(args[3]), short.Parse(args[4]), decimal.Parse(args[5], _fp));
		}

		private Stock CreateStock(string[] args)
		{
			return new Stock(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
		}

		private Store CreateStore(string[] args)
		{
			return new Store(int.Parse(args[0]), args[1], args[2], args[3], args[4], args[5], args[6], args[7]);
		}

		private Staff CreateStaff(string[] args)
		{
			int? managerId = args[7] == "NULL" ? (int?)null : int.Parse(args[7]);
			return new Staff(int.Parse(args[0]), byte.Parse(args[5]), int.Parse(args[6]), managerId, args[1], args[2], args[3], args[4]);
		}

		#region НЕ ИСПОЛЬЗУЕТСЯ

		private T CreateItem<T>(string[] input)
		{
			if (typeof(T) == typeof(Brand))
			{
				ConstructorInfo ctr = typeof(T).GetConstructor(new Type[] { typeof(string), typeof(int) });
				return (T)ctr.Invoke(new object[] { input[1], int.Parse(input[0]) });
			}
			throw new ArgumentException($"Cannot find suitable ctor for type {typeof(T)}");
		}

		#endregion НЕ ИСПОЛЬЗУЕТСЯ
	}
}