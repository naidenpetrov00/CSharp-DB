namespace CarSystem.Data
{
    public static class DataValidations
    {
        public static class Make
        {
            public const int MaxName = 20;
        }

        public static class Model
        {
            public const int MaxName = 20;
            public const int ModificationName = 50;
        }

        public static class Car
        {
            public const int VinLength = 17;
            public const int ColorMax = 15;
        }

        public static class Customer
        {
            public const int MaxName = 30;
        }

        public static class Address
        {
            public const int MaxLength = 200; 
        }
    }
}
