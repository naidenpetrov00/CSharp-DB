namespace CarSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataValidations.Make;

    public class Make
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxName)]
        public string Name { get; set; }
    }
}
