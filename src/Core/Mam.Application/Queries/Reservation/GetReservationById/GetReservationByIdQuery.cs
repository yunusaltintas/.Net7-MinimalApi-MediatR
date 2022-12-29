using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Application.Queries.Reservation.GetReservationById
{
    public class GetReservationByIdQuery : IRequest<ReservationByIdDto>
    {
        public GetReservationByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
