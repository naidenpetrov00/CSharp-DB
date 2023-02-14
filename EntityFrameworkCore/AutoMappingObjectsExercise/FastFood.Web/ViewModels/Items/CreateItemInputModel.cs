using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Web.ViewModels.Items
{
    public class CreateItemInputModel
    {
        public string Name { get; set; }

		public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
