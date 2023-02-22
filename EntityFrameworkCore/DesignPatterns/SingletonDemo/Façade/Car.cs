namespace SingletonDemo.Façade
{
	public class Car
	{
		public string Type { get; set; }
		public string Color { get; set; }
		public int NumberOfDooors { get; set; }

		public string City { get; set; }
		public string Address { get; set; }

		public override string ToString()
		{
			return $"{Type}, {Color}, {NumberOfDooors}, {City}, {Address}";
		}
	}
}
