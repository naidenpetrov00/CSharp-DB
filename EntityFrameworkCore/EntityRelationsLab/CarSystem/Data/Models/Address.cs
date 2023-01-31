namespace CarSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Address;

    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLength)]
        public string Text { get; set; }

        public string Town { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
