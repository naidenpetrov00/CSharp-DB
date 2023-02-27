﻿namespace PetStore.Services.Implementations
{
	using PetStore.Data.Models;
	using PetStore.Services.Models.Food;

	public class FoodService : IFoodService
	{
		private readonly PetStoreDbContext data;

		public FoodService(PetStoreDbContext data)
		{
			this.data = data;
		}

		public void BuyFromDistributor(string name, double weight, decimal price,
			double profit, DateTime expirationDate, int brandId, int categoryId)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentException("Name cannot be null or whitespace");
			}
			if (profit < 0 || profit > 5)
			{
				throw new ArgumentException("Profit must be higher than 0% and lower than 500%");
			}

			var food = new Food()
			{
				Name = name,
				Weight = weight,
				DistributorPrice = price,
				Price = price + (price * (decimal)profit),
				ExpirationDate = expirationDate,
				BrandId = brandId,
				CategoryId = categoryId
			};

			this.data.Food.Add(food);
			this.data.SaveChanges();
		}

		public void BuyFromDistributor(AddingFoodServiceModel model)
		{
			if (String.IsNullOrWhiteSpace(model.Name))
			{
				throw new ArgumentException("Name cannot be null or whitespace");
			}
			if (model.Profit < 0 || model.Profit > 5)
			{
				throw new ArgumentException("Profit must be higher than 0% and lower than 500%");
			}

			var food = new Food()
			{
				Name = model.Name,
				Weight = model.Weight,
				DistributorPrice = model.Price,
				Price = model.Price + (model.Price * (decimal)model.Profit),
				BrandId = model.BrandId,
				CategoryId = model.CategoryId
			};

			this.data.Food.Add(food);
			this.data.SaveChanges();
		}
	}
}
