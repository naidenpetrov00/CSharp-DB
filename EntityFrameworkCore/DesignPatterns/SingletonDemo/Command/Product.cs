namespace SingletonDemo.Command
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void IncreasePrice(int amount)
        {
            Price += amount;
            Console.WriteLine($"Price for {Name} increased by {amount}");
        }

        public void DecreasePrice(int amount)
        {
            if (amount <= Price)
            {
                Price -= amount;
                Console.WriteLine($"Price for {Name} decreased by {amount}");
            }
            else
            {
                Console.WriteLine("Cannot decrease with more than available");
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Price}";
        }
    }
}
