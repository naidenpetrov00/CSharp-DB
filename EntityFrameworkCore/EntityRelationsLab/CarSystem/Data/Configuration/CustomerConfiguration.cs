﻿namespace CarSystem.Data.Configuration
{
    using CarSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> customer)
        {
            customer
            .HasOne(c => c.Address)
            .WithOne(a => a.Customer)
            .HasForeignKey<Address>(a => a.CustomerId);
        }
    }
}
