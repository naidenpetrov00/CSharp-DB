namespace PetStore.Services.Implementations
{
	using PetStore.Data.Models;

	public class CategoryService : ICategoryService
	{
		private readonly PetStoreDbContext data;

		public CategoryService(PetStoreDbContext data)
		{
			this.data = data;
		}

		public bool Exists(int id)
		{
			return this.data.Categories.Any(c => c.Id == id);
		}
	}
}
