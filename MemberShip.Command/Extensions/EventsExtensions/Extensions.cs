using MemberShip.Command.Features.Invitations.Command.SendInvitaion;
using MemberShip.Command.StronglyTypedIDs;
using MemberShip.Command.Features.Invitations.Command.CancelInvitaion;
using MemberShip.Command.Events.InvitationEvents.InvitationCanceled;
using MemberShip.Command.Features.Invitations.Command.AcceptInvitaion;
using MemberShip.Command.Events.InvitationEvents.InvitationAccepted;
using MemberShip.Command.Features.Invitations.Command.RejectInvitaion;
using MemberShip.Command.Events.InvitationEvents.InvitationRejected;
using MemberShip.Command.Events.InvitationEvents.InvitationSent;

namespace MemberShip.Command.Extensions.EventsExtensions;

public static class Extensions
{
    public static InvitationSent ToEvent(this SendInvitationCommand cmd) =>
        new(
           AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId, (MemberId)cmd.MemberId),
           Sequence: 1,
            DateTime: DateTime.UtcNow,
            UserId: cmd.UserId,
            Version: 1,

            Data: new InvitationSentData(
                 AccountId: cmd.AccountId,
                 MemberId: cmd.MemberId,
                 UserId: cmd.UserId,
                 SubscriptionId: cmd.SubscrptionId)
            );
    public static InvitationSent ToEvent(this SendInvitationCommand cmd, int Sequence) =>
        new(
           AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId, (MemberId)cmd.MemberId),

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
    public static InvitationCanceled ToEvent(this CancelInvitaionCommand cmd, int Sequence) =>
        new(
           AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId, (MemberId)cmd.MemberId),

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
           AggregateId: new AggregateId((SubscrptionId)cmd.SubscrptionId, (MemberId)cmd.MemberId),

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
