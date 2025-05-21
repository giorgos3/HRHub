using HRHub.Domain.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRHub.Infrastructure.Configurations
{
    internal sealed class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("Request");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.UserId).IsRequired();
            builder.Property(r => r.ManagerId).IsRequired();

            builder.OwnsOne(r => r.Duration, duration =>
            {
                duration.Property(d => d.Start).HasColumnName("StartDate");
                duration.Property(d => d.End).HasColumnName("EndDate");
            });

            builder.Property(r => r.Status);
            builder.Property(r => r.CreatedOnUtc);
            builder.Property(r => r.ConfirmedOnUtc);
            builder.Property(r => r.RejectedOnUtc);
            builder.Property(r => r.CompletedOnUtc);
            builder.Property(r => r.CancelledOnUtc);

        }
    }
}
