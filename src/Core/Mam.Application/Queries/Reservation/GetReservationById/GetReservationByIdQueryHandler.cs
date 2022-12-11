using Mam.Application.Interfaces.IRepository;
using Mam.Application.Mapping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Application.Queries.Reservation.GetReservationById
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationByIdDto>
    {
        private readonly IGenericRepository<Domain.Entities.Reservation> repository;

        public GetReservationByIdQueryHandler(IGenericRepository<Domain.Entities.Reservation> repository)
        {
            this.repository = repository;
        }
        public async Task<ReservationByIdDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetByIdAsync(request.Id);
            return response.ToReservationByIdDto();
        }
    }
}
