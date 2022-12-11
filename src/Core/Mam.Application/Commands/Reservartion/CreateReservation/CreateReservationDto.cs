using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Application.Commands.Reservartion.CreateReservation
{
    public class CreateReservationDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public DateTime ReservartionDate { get; set; }
    }
}
