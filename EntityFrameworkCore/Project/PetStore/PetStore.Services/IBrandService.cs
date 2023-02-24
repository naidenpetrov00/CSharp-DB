namespace PetStore.Services
{
	using PetStore.Services.Models.Brand;

	public interface IBrandService
	{
		int Create(string name);

		IEnumerable<BrandListingServiceModel> SearchByName(string name);
	}
}
