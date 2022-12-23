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
}
