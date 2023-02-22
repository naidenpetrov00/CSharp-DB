using SingletonDemo.Command;
using SingletonDemo.Façade;
using SingletonDemo.Singleton;

namespace SingletonDemo
{
    public class Program
	{
		static void Main(string[] args)
		{
			//var db = SingletonDataContainer.Instance;
			//Console.WriteLine(db.GetPopulation("Sofiq"));

			//var car = new CarBuilderFacade()
			//	.Info
			//		.WithType("BMW")
			//		.WithColor("Black")
			//	.Built
			//		.InCity("Leipsig")
			//		.AtAddress("255")
			//	.Build();

			//Console.WriteLine(car);

			var modifyPrice = new ModifyPrice();
			var product = new Product("Phone", 500);

			Console.WriteLine(product);

			modifyPrice.SetCommand(new ProductCommand(product, PriceAction.Increase, 100));
			modifyPrice.Invoke();

			Console.WriteLine(product);
		}
	}
}