namespace CarSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Customer;

    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxName)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(MaxName)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<CarPurchase> Purchases { get; set; } = new HashSet<CarPurchase>();

        public Address Address { get; set; }
    }
}
