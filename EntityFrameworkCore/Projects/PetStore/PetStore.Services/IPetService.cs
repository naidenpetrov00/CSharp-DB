﻿namespace PetStore.Services
{
	using PetStore.Data.Models;
	using PetStore.Services.Models.Pet;

	public interface IPetService
	{
		IEnumerable<PetListingServiceModel> All(int page = 1);

		PetDetailsServiceModel Details(int id);

		void BuyPet(Gender gender, DateTime dateOfBirth, decimal price,
			string description, int breedId, int categoryId);

		void SellPet(int petId, int userId);

		bool Exists(int id);

		int Total();
		bool Delete(int id);
	}
}