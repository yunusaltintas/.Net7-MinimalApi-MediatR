using Mam.Application.Commands.Reservartion.CreateReservation;
using Mam.Application.Queries.Reservation.GetReservationById;
using Mam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Application.Mapping
{
    public static class RequestToDomainMapper
    {
        public static Reservation ToReservation(this CreateReservationCommand request)
        {
            return new Reservation
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                ReservartionDate = request.ReservationDate
            };
        }
    }
}
