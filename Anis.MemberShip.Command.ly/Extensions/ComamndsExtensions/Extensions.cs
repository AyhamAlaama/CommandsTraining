using Anis.MemeberShip.Command.ly.Features.Invitations.Command.SendInvitaion;
using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationSent;
using Anis.MemeberShip.Command.ly.Features.Invitations.Command.CancelInvitaion;
using Anis.MemeberShip.Command.ly.Features.Invitations.Command.AcceptInvitaion;
using Anis.MemeberShip.Command.ly.Features.Invitations.Command.RejectInvitaion;
using Anis.MemeberShip.Command.ly.v1;

namespace Anis.MemeberShip.Command.ly.Extensions.ComamndsExtensions;

public static class Extensions
{
    public static SendInvitationCommand ToCommand(this SendInvitationRequest request) =>
        new (){
            AccountId= request.AccountId,
            MemberId= request.MemberId,
            SubscrptionId= request.SubscrptionId,
            UserId  = request.UserId
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
