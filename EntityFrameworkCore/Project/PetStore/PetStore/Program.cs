namespace PetStore
{
	using PetStore.Data.Models;
	using PetStore.Services.Implementations;

	public class Program
	{
		public static void Main()
		{

			using var data = new PetStoreDbContext();

			var foodService = new FoodService(data);

			foodService.BuyFromDistributor("Meat", 0.350, 1.5m, 0.3, DateTime.UtcNow, 1, 2);
		}
	}
}