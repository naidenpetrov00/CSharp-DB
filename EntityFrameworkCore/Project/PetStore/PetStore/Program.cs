namespace PetStore
{
	using PetStore.Data.Models;
	using PetStore.Services.Implementations;

	public class Program
	{
		public static void Main()
		{

			using var data = new PetStoreDbContext();
			var userService = new UserService(data);
			var foodService = new FoodService(data, userService);
			var toyService = new ToyService(data, userService);
			var breedService = new BreedService(data);
			var categoryService = new CategoryService(data);
			var petService = new PetService(data, breedService, categoryService, userService); 

			//userService.Register("Pesho", "pesho123@gmail.com");
			//foodService.SellFoodToUser(3, 1);
			//toyService.SellToyToUser(2, 1); 
			//breedService.Add("Persian");
			petService.BuyPet(Gender.Male, DateTime.UtcNow, 0m, null, 1, 2);
			petService.SellPet(1, 1);
		}
	}
}