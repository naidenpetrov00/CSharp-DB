namespace CatsDbExample.models
{
    using System.ComponentModel.DataAnnotations;

    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Cat> Cats { get; set; } = new List<Cat>();
    }
}
