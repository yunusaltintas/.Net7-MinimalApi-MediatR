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
    public static class DomainToDtoMapper
    {
        public static CreateReservationDto ToCreateReservationDto(this Reservation entity)
        {
            return new CreateReservationDto
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                ReservartionDate = entity.ReservartionDate
            };
        }

        public static ReservationByIdDto ToReservationByIdDto(this Reservation entity)
        {
            return new ReservationByIdDto
            {
                Id = entity.Id,
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                ReservartionDate = entity.ReservartionDate
            };
        }
    }
}
