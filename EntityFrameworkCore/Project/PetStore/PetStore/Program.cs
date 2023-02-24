namespace PetStore
{
	using PetStore.Data.Models;
	using PetStore.Services.Implementations;

	public class Program
	{
		public static void Main()
		{
			using var data = new PetStoreDbContext();

			var brandService = new BrandService(data);

			brandService.Create("Purrina");
		}
	}
}