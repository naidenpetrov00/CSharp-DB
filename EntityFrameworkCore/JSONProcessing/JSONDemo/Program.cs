namespace JSONDemo
{
	using Newtonsoft.Json;

	public class Program
	{
		public static void Main(string[] args)
		{
			var inputJson = File.ReadAllText("../../../products.json");

			var products = JsonConvert.DeserializeObject<ProductDto[]>(inputJson);

			var json = JsonConvert.SerializeObject(products, Formatting.Indented);

			Console.WriteLine(json);
		}
	}
}