using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mam.Application.Commands.Reservartion.UpdateReservation
{
    public class UpdateReservationCommandHandler : AsyncRequestHandler<UpdateReservationCommand>
    {
        protected override Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
