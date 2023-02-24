namespace PetStore.Data.Models
{
	using static DataValidation;
	using System.ComponentModel.DataAnnotations;
	public class Brand
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; }

		public ICollection<Toy> Toys { get; set; } = new HashSet<Toy>();

		public ICollection<Food> Food { get; set; } = new HashSet<Food>();
	}
}
