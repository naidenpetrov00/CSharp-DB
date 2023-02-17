namespace ProductShop
{
	using System;
	using System.IO;
	using Newtonsoft.Json;
	using ProductShop.Data;
	using ProductShop.Models;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			using var db = new ProductShopContext();

			var usersJson = File.ReadAllText("./../../../Datasets/users.json");
			var productsJson = File.ReadAllText("./../../../Datasets/products.json");
			var categoriesJson = File.ReadAllText("./../../../Datasets/categories.json");
			var categoryProductsJson = File.ReadAllText("./../../../Datasets/categories-products.json");

			Console.WriteLine(ImportCategoryProducts(db, categoryProductsJson));
		}
		 
		public static string ImportUsers(ProductShopContext db, string inputJson)
		{
			var users = JsonConvert.DeserializeObject<User[]>(inputJson);

			db.Users.AddRange(users);
			db.SaveChanges();

			return $"Successfully imported {users.Length}";
		}

		public static string ImportProducts(ProductShopContext db, string inputJson)
		{
			var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

			db.Products.AddRange(products);
			db.SaveChanges();

			return $"Successfully imported {products.Length}";
		}

		public static string ImportCategories(ProductShopContext db, string inputJson)
		{
			var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);

			db.Categories.AddRange(categories);
			db.SaveChanges();

			return $"Successfully imported {categories.Length}";
		}

		public static string ImportCategoryProducts(ProductShopContext db, string inputJson)
		{
			var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

			db.CategoryProducts.AddRange(categoryProducts);
			db.SaveChanges();

			return $"Successfully imported {categoryProducts.Length}";
		}
	}
}