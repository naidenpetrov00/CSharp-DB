namespace PetStore.Services
{
	using PetStore.Services.Models.Food;

	public interface IToyService
	{
		void BuyFromDistributer(string name, string description, decimal distributorPrice,
			double profit, int brandId, int categoryId);

		void BuyFromDistributor(AddingToyServiceModel model);
	}
}
