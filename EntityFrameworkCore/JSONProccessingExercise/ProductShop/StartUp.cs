namespace ProductShop
{
	using ProductShop.Data;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			using var db = new ProductShopContext();

			db.Database.EnsureCreated();
		}
	}
}