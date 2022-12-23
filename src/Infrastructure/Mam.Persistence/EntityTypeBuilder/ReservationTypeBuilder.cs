using Mam.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Persistence.EntityTypeBuilder
{
    public class ReservationTypeBuilder : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(150);

            builder.Property(p => p.PhoneNumber)
               .IsRequired()
               .HasColumnType("nvarchar")
               .HasMaxLength(150);

            builder.Property(p => p.ReservartionDate)
              .IsRequired()
              .HasColumnType("datetime");
        }
    }
}
