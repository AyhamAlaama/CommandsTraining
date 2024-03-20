using Anis.MemeberShip.Command.ly.Extensions.ComamndsExtensions;
using Anis.MemeberShip.Command.ly.v1;

using Grpc.Core;


namespace Anis.MemeberShip.Command.ly.Services
{
    public class MemberShipService : BaseDomain.MemberShipBase
    {
        private readonly IMediator _mediator;
        public MemberShipService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task<InvitationResponse> SendInvitation(SendInvitationRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invitationResponse = await _mediator.Send(command);

            return invitationResponse;


        }

        public override async Task<InvitationResponse> CancelInvitation(CancelInvitationRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invitationResponse = await _mediator.Send(command);

            return invitationResponse;
        }
        public override async Task<InvitationResponse> AcceptInvitation(AcceptInvitationRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invitationResponse = await _mediator.Send(command);

            return invitationResponse;
        }
        public override async Task<InvitationResponse> RejectInvitation(RejectInvitationRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var invitationResponse = await _mediator.Send(command);

            return invitationResponse;
        }
    }
}