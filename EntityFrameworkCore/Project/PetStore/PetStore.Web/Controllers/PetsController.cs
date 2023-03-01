﻿namespace PetStore.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using PetStore.Services;
	using PetStore.Services.Models.Pet;

	public class PetsController : Controller
	{
		private readonly IPetService pets;

		public PetsController(IPetService pets)
		{
			this.pets = pets;
		}

		public IEnumerable<PetListingServiceModel> All()
			=> this.pets.All();
	}
}
