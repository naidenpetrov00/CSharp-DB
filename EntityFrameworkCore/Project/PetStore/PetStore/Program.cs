namespace PetStore
{
	using PetStore.Data.Models;

	public class Program
	{
		public static void Main()
		{
			using var data = new PetStoreDbContext();

			for (int i = 0; i < 10; i++)
			{
				var breed = new Breed()
				{
					Name = "Breed" + i,
				};

				data.Breeds.Add(breed);
			}

			data.SaveChanges();

			for (int i = 0; i < 30; i++)
			{
				var category = new Category()
				{
					Name = "Category" + i
				};

				data.Categories.Add(category);
			}

			data.SaveChanges();

			for (int i = 0; i < 100; i++)
			{
				var categoryId = data
					.Categories
					.OrderBy(c => Guid.NewGuid())
					.Select(c => c.Id)
					.FirstOrDefault();

				var breedId = data
					.Breeds
					.OrderBy(b => Guid.NewGuid())
					.Select(b => b.Id)
					.FirstOrDefault();

				var pet = new Pet
				{
					DateOfBirth = DateTime.UtcNow.AddDays(-60 + i),
					Price = 50 + i,
					Gender = i % 2 == 0 ? Gender.Male : Gender.Female,
					CategoryId = categoryId,
					BreedId = breedId
				};

				data.Pets.Add(pet);
			}

			data.SaveChanges();
		}
	}
}