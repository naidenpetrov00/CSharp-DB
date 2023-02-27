namespace PetStore.Services.Implementations
{
	using Microsoft.Identity.Client;
	using PetStore.Data.Models;
	using PetStore.Services.Models.Food;

	public class ToyService : IToyService
	{
		private readonly PetStoreDbContext data;

		public ToyService(PetStoreDbContext data)
		{
			this.data = data;
		}

		public void BuyFromDistributer(string name, string description, decimal distributorPrice, double profit, int brandId, int categoryId)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Name cannot be null or whitespace");
			}
			if (profit < 0 || profit > 5)
			{
				throw new ArgumentException("Profit must be higher than 0 and lower than 500");
			}

			var toy = new Toy()
			{
				Name = name,
				Description = description,
				DistributorPrice = distributorPrice,
				Price = distributorPrice + (distributorPrice * (decimal)profit),
				BrandId = brandId,
				CategoryId = categoryId
			};

			this.data.Toys.Add(toy);
			this.data.SaveChanges();
		}

		public void BuyFromDistributor(AddingToyServiceModel model)
		{
			if (String.IsNullOrWhiteSpace(model.Name))
			{
				throw new ArgumentNullException("Name cannot be null or whitespace");
			}
			if (model.Profit < 0 || model.Profit > 5)
			{
				throw new ArgumentException("Profit must be higher than 0 and lower than 500");
			}

			var toy = new Toy()
			{
				Name = model.Name,
				Description = model.Description,
				DistributorPrice = model.Price,
				Price = model.Price + (model.Price * (decimal)model.Profit),
				BrandId = model.BrandId,
				CategoryId = model.CategoryId
			};

			this.data.Toys.Add(toy);
			this.data.SaveChanges();
		}
	}
}
