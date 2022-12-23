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
        private readonly IRepository<Domain.Entities.Reservation> _repository;

        public GetReservationByIdQueryHandler(IRepository<Domain.Entities.Reservation> repository)
        {
            _repository = repository;
        }
        public async Task<ReservationByIdDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetByIdAsync(request.Id);
            return response.ToReservationByIdDto();
        }
    }
}
