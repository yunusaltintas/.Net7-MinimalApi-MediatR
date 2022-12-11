using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Domain.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public DateTime ReservartionDate { get; set; }
    }


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
