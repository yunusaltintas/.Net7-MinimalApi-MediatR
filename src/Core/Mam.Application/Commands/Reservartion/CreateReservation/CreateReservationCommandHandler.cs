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
        public IUnitOfWork unitOfWork { get; }
        private readonly IGenericRepository<Domain.Entities.Reservation> repository;

        public CreateReservationCommandHandler(IGenericRepository<Domain.Entities.Reservation> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<CreateReservationDto> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {

            var response = await repository.AddAsync(request.ToReservation());
            await unitOfWork.CommitAsync();

            return response.ToCreateReservationDto();
        }
    }
}
