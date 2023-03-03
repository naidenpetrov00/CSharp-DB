namespace PetStore.Services.Implementations
{
	using PetStore.Data.Models;
	using PetStore.Services.Models.Brand;

	public class BrandService : IBrandService
	{

		private readonly PetStoreDbContext data;

		public BrandService(PetStoreDbContext data)
		{
			this.data = data;
		}

		public int Create(string name)
		{
			if (name.Length > DataValidation.NameMaxLength)
			{
				throw new InvalidOperationException($"Name cannot be more than ${DataValidation.NameMaxLength}");
			}

			if (this.Exists(name))
			{
				throw new InvalidOperationException($"Brand name {name} already exists");
			}

			var brand = new Brand
			{
				Name = name,
			};

			this.data.Brands.Add(brand);
			this.data.SaveChanges();

			return brand.Id;
		}

		public bool Exists(string name)
		{
			return this.data.Brands.Any(b => b.Name == name);
		}

		public IEnumerable<BrandListingServiceModel> SearchByName(string name)
		{
			return this.data.Brands
				.Where(b => b.Name.ToLower().Contains(name.ToLower()))
				.Select(b => new BrandListingServiceModel
				{
					Id = b.Id,
					Name = b.Name,
				})
				.ToList();
		}
	}
}
