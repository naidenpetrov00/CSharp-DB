namespace JSONDemo
{
	using Newtonsoft.Json;
	using Newtonsoft.Json.Serialization;

	public class Program
	{
		public static void Main(string[] args)
		{
			var inputJson = File.ReadAllText("../../../products.json");

			var products = JsonConvert.DeserializeObject<ProductDto[]>(inputJson);

			var resolver = new DefaultContractResolver()
			{
				NamingStrategy = new KebabCaseNamingStrategy()
			}; 

			var json = JsonConvert.SerializeObject(products, Formatting.Indented);

			Console.WriteLine(json);
		}
	}
} 