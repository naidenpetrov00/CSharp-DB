namespace PetStore.Services.Implementations
{
	using PetStore.Data.Models;

	public class BreedService : IBreedService
	{
		private readonly PetStoreDbContext data;

		public BreedService(PetStoreDbContext data)
		{
			this.data = data;
		}

		public void Add(string name)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Breed name cannot be null or whitespace!");
			}

			var bread = new Breed()
			{
				Name = name,
			};

			this.data.Breeds.Add(bread);
			this.data.SaveChanges();
		}

		public bool Exists(int id)
		{
			return this.data.Breeds.Any(b => b.Id == id);
		}
	}
}
