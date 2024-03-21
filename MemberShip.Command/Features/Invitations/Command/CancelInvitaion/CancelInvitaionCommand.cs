﻿using MemberShip.Command.v1;
using MediatR;
namespace MemberShip.Command.Features.Invitations.Command.CancelInvitaion;

public class CancelInvitaionCommand : IRequest<InvitationResponse>
{
    public required string AccountId { get; init; }
    public required string SubscrptionId { get; init; }
    public required string MemberId { get; init; }
    public required string UserId { get; init; }
}
