﻿namespace PetStore.Services.Implementations
{
	using PetStore.Data.Models;
	using PetStore.Services.Models.Pet;
	using System.Collections.Generic;

	public class PetService : IPetService
	{
		private const int PetsPageSize = 25;

		private readonly PetStoreDbContext data;
		private readonly IBreedService breedService;
		private readonly ICategoryService categoryService;
		private readonly IUserService userService;

		public PetService(PetStoreDbContext data, IBreedService breedService, ICategoryService categoryService, IUserService userService)
		{
			this.data = data;
			this.breedService = breedService;
			this.categoryService = categoryService;
			this.userService = userService;
		}

		public void BuyPet(Gender gender, DateTime dateOfBirth, decimal price,
			string description, int breedId, int categoryId)
		{
			if (price < 0)
			{
				throw new ArgumentException("Price cannot be below 0");
			}
			if (!this.breedService.Exists(breedId))
			{
				throw new ArgumentException("There is no such breed");
			}
			if (!this.categoryService.Exists(categoryId))
			{
				throw new ArgumentException("There is no such category");
			}

			var pet = new Pet()
			{
				Gender = gender,
				DateOfBirth = dateOfBirth,
				Price = price,
				Description = description,
				BreedId = breedId,
				CategoryId = categoryId
			};

			this.data.Pets.Add(pet);
			this.data.SaveChanges();
		}

		public void SellPet(int petId, int userId)
		{
			if (!this.userService.Exists(userId))
			{
				throw new ArgumentException("There is no such user");
			}
			if (!this.Exists(petId))
			{
				throw new ArgumentException("There is no such pet");
			}

			var pet = this.data.Pets
				.FirstOrDefault(p => p.Id == petId);

			var order = new Order()
			{
				PurchaseDate = DateTime.UtcNow,
				Status = OrderStatus.Done,
				UserId = userId
			};

			this.data.Orders.Add(order);
			pet.Order = order;
		}

		public bool Exists(int id)
			=> this.data
			.Pets
			.Any(p => p.Id == id);

		public IEnumerable<PetListingServiceModel> All(int page = 1)
			=> this.data
			.Pets
			.Skip((page - 1) * PetsPageSize)
			.Take(PetsPageSize)
			.Select(p => new PetListingServiceModel()
			{
				Id = p.Id,
				Price = p.Price,
				Category = p.Category.Name,
				Breed = p.Breed.Name
			})
			.ToList();
	}
}
