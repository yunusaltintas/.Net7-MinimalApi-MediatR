using Mam.Application.Interfaces.IRepository;
using Mam.Application.Interfaces.IUnitOfWork;
using Mam.Application.Mapping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Application.Commands.Reservartion.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, CreateReservationDto>
    {
        public IUnitOfWork _unitOfWork { get; }
        private readonly IRepository<Domain.Entities.Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Domain.Entities.Reservation> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<CreateReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {

            var response = await _repository.AddAsync(request.ToReservation());
            await _unitOfWork.CommitAsync();

            return response.ToCreateReservationDto();
        }
    }
}
