using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Application.Commands.Reservartion.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, UpdateReservationDto>
    {
        public Task<UpdateReservationDto> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {

            //write cod
            throw new NotImplementedException();
        }
    }
}
