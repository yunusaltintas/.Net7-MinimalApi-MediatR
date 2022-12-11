using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Application.Commands.Reservartion.CreateReservation
{
    public class CreateReservationCommand : IRequest<CreateReservationDto>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
