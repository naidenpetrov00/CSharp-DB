namespace SingletonDemo.Façade
{
	public class CarInfoBuilder : CarBuilderFacade
	{
		public CarInfoBuilder(Car car)
		{
			this.Car = car;
		}

		public CarInfoBuilder WithType(string type)
		{
			this.Car.Type = type;
			return this;
		}

		public CarBuilderFacade WithColor(string color)
		{
			this.Car.Color = color;
			return this;
		}
	}
}
