namespace CatsDbExample.models
{
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string Color { get; set; }

        public int OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}
