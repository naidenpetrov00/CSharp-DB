namespace SingletonDemo.Singleton
{
    using System.Runtime.CompilerServices;

    public class SingletonDataContainer : ISingletonContainer
    {
        private static SingletonDataContainer instance = new SingletonDataContainer();

        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Intializing singleton object...");

            var elements = File.ReadAllLines("../../../Singleton/capitals.txt");
            for (int i = 0; i < elements.Length; i += 2)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
