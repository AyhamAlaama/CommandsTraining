using MemberShip.Command.Features.Invitations.Command.SendInvitaion;
using MemberShip.Command.Events.InvitationEvents.InvitationSent;
using MemberShip.Command.Features.Invitations.Command.CancelInvitaion;
using MemberShip.Command.Features.Invitations.Command.AcceptInvitaion;
using MemberShip.Command.Features.Invitations.Command.RejectInvitaion;
using MemberShip.Command.v1;

namespace MemberShip.Command.Extensions.ComamndsExtensions;

public static class Extensions
{
    public static SendInvitationCommand ToCommand(this SendInvitationRequest request) =>
        new()
        {
            AccountId = request.AccountId,
            MemberId = request.MemberId,
            SubscrptionId = request.SubscrptionId,
            UserId = request.UserId
        };
    public static CancelInvitaionCommand ToCommand(this CancelInvitationRequest request) =>
       new()
       {
           AccountId = request.AccountId,
           MemberId = request.MemberId,
           SubscrptionId = request.SubscrptionId,
           UserId = request.UserId
       };
    public static AcceptInvitaionCommand ToCommand(this AcceptInvitationRequest request) =>
       new()
       {
           AccountId = request.AccountId,
           MemberId = request.MemberId,
           SubscrptionId = request.SubscrptionId,
           UserId = request.UserId
       };
    public static RejectInvitaionCommand ToCommand(this RejectInvitationRequest request) =>
      new()
      {
          AccountId = request.AccountId,
          MemberId = request.MemberId,
          SubscrptionId = request.SubscrptionId,
          UserId = request.UserId
      };
}
