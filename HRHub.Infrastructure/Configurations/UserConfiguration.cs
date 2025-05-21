using HRHub.Domain.Request;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRHub.Domain.Users;



namespace HRHub.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName)
                .HasMaxLength(255).
                HasConversion(firstName => firstName.Value, value => new FirstName(value));

            builder.Property(user => user.LastName)
                .HasMaxLength(255).
                HasConversion(lastName => lastName.Value, value => new LasttName(value));

            builder.Property(user => user.Email)
                .HasMaxLength(255).
                HasConversion(email => email.Value, value => new Domain.Users.Email(value));

            builder.Property(user => user.RemaingLeave).IsRequired();

            builder.Property(user => user.Role).IsRequired(); 

            builder.HasIndex(user => user.Email).IsUnique();




        }
    }
}
