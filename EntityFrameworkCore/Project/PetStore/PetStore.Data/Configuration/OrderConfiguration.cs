using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data.Configuration
{
	internal class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder
				.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(u => u.UserId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
