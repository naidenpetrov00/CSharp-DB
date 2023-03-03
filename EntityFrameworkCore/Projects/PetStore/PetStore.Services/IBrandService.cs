namespace PetStore.Services
{
	using PetStore.Data.Models;
	using PetStore.Services.Models.Brand;

	public interface IBrandService
	{
		int Create(string name);

		IEnumerable<BrandListingServiceModel> SearchByName(string name);

		bool Exists(string name);
	}
}
