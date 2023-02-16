namespace ProductShop
{
	using AutoMapper;
	using ProductShop.Data;

	public class ProductShopProfile : Profile
	{
		public ProductShopProfile()
		{
			using var db = new ProductShopContext();

		}
	}
}
