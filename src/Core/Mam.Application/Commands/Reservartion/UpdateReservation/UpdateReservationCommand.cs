using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mam.Application.Commands.Reservartion.UpdateReservation
{
    public class UpdateReservationCommand : IRequest<UpdateReservationDto>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
