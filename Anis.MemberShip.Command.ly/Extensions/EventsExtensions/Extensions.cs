using Anis.MemeberShip.Command.ly.Features.Invitations.Command.SendInvitaion;
using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationSent;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;
using Anis.MemeberShip.Command.ly.Features.Invitations.Command.CancelInvitaion;
using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationCanceled;
using Anis.MemeberShip.Command.ly.Features.Invitations.Command.AcceptInvitaion;
using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationAccepted;
using Anis.MemeberShip.Command.ly.Features.Invitations.Command.RejectInvitaion;
using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationRejected;

namespace Anis.MemeberShip.Command.ly.Extensions.EventsExtensions;

public static class Extensions
{
    public static InvitationSent ToEvent(this SendInvitationCommand cmd) =>
        new(
           AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId,(MemberId)cmd.MemberId),
           Sequence: 1,
            DateTime: DateTime.UtcNow,
            UserId: cmd.UserId,
            Version:1,

            Data: new InvitationSentData ( 
                 AccountId: cmd.AccountId,
                 MemberId:cmd.MemberId,
                 UserId:cmd.UserId,
                 SubscriptionId:cmd.SubscrptionId)
            );
    public static InvitationSent ToEvent(this SendInvitationCommand cmd, int Sequence) =>
        new(
           AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId,(MemberId)cmd.MemberId),

           Sequence: Sequence,
            DateTime: DateTime.UtcNow,
            UserId: cmd.UserId,
            Version: 1,

            Data: new InvitationSentData(
                 AccountId: cmd.AccountId,
                 MemberId: cmd.MemberId,
                 UserId: cmd.UserId,
                 SubscriptionId: cmd.SubscrptionId)
            );
    public static InvitationCanceled ToEvent(this CancelInvitaionCommand cmd,int Sequence) =>
        new(
           AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId,(MemberId)cmd.MemberId),

           Sequence: Sequence,
            DateTime: DateTime.UtcNow,
            UserId: cmd.UserId,
            Version: 1,

            Data: new InvitationCanceledData(
                
                 AccountId: cmd.AccountId,
                 MemberId: cmd.MemberId,
                 UserId: cmd.UserId,
                 SubscriptionId: cmd.SubscrptionId)
            );
    public static InvitationAccepted ToEvent(this AcceptInvitaionCommand cmd, int Sequence) =>
        new(
           AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId,(MemberId)cmd.MemberId),

           Sequence: Sequence, 
            DateTime: DateTime.UtcNow,
            UserId: cmd.UserId,
            Version: 1,

            Data: new InvitationAcceptedData(
              
                 AccountId: cmd.AccountId,
                 MemberId: cmd.MemberId,
                 UserId: cmd.UserId,
                 SubscriptionId: cmd.SubscrptionId)
            );
    public static InvitationRejected ToEvent(this RejectInvitaionCommand cmd, int Sequence) =>
      new(
         AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId, (MemberId)cmd.MemberId),
         Sequence: Sequence,
          DateTime: DateTime.UtcNow,
          UserId: cmd.UserId,
          Version: 1,

          Data: new InvitationRejectedData(
             
               AccountId: cmd.AccountId,
               MemberId: cmd.MemberId,
               UserId: cmd.UserId,
               SubscriptionId: cmd.SubscrptionId)
          );
}
