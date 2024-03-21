using MemberShip.Command.Events.InvitationEvents.InvitationAccepted;
using MemberShip.Command.Events.InvitationEvents.InvitationCanceled;
using MemberShip.Command.Events.InvitationEvents.InvitationRejected;
using MemberShip.Command.Events.InvitationEvents.InvitationSent;
using MemberShip.Command.Exceptions;
using MemberShip.Command.Extensions.EventsExtensions;
using MemberShip.Command.Features.Invitations.Command.AcceptInvitaion;
using MemberShip.Command.Features.Invitations.Command.CancelInvitaion;
using MemberShip.Command.Features.Invitations.Command.RejectInvitaion;
using MemberShip.Command.Features.Invitations.Command.SendInvitaion;
namespace MemberShip.Command.Domain;
public class MemberShip : Aggregate<MemberShipDomain>, IAggregate
{

    private MemberShip() { }
    public static bool HasPendingInvitation { get; private set; }
    public static bool IsJoined { get; private set; }



    protected override void Mutate(Event @event)
    {
        switch (@event)
        {
            case InvitationSent e:
                Mutate(e);
                break;
            case InvitationCanceled e:
                Mutate(e);
                break;
            case InvitationAccepted e:
                Mutate(e);
                break;
            case InvitationRejected e:
                Mutate(e);
                break;

        }
    }
    //Add New Member To subscrption ( Invite ) 
    public static MemberShipDomain AddToSubscription(SendInvitationCommand cmd)
    {
        var member = new MemberShipDomain();
        member.ApplyNewChange(cmd.ToEvent());
        return member;
    }
    public void SendNewInvitation(SendInvitationCommand cmd)
    {
        if (HasPendingInvitation) throw new AlreadyException("Has Pending Invitation !");
        if (IsJoined) throw new AlreadyException($"{nameof(SendNewInvitation)}: Member Already Joined !");

        ApplyNewChange(cmd.ToEvent(NextSequence));

    }
    //cancel
    public void CancelInvitation(CancelInvitaionCommand cmd)
    {
        if (!HasPendingInvitation) throw new AlreadyException("There is no invitation for this subscription !");
        if (IsJoined) throw new AlreadyException($"{nameof(CancelInvitation)}:Member Already Joined !");
        ApplyNewChange(cmd.ToEvent(NextSequence));
    }
    //Accept
    public void AcceptInvitation(AcceptInvitaionCommand cmd)
    {
        if (!HasPendingInvitation) throw new AlreadyException("There is no invitation for this subscription !");
        if (IsJoined) throw new AlreadyException($"{nameof(AcceptInvitation)}: u r Already Joined !");
        ApplyNewChange(cmd.ToEvent(NextSequence));
    }
    public void RejectInvitation(RejectInvitaionCommand cmd)
    {
        if (!HasPendingInvitation) throw new AlreadyException("There is no invitation for this subscription !");
        if (IsJoined) throw new AlreadyException($"{nameof(RejectInvitation)}: u r Already Joined !");
        ApplyNewChange(cmd.ToEvent(NextSequence));
    }


    //Mutate Canceled Event
    public void Mutate(InvitationCanceled _) //each event has mutate method
    {
        HasPendingInvitation = false;
        IsJoined = false;

    }
    //Mutate Sent Event
    public void Mutate(InvitationSent _)
    {
        HasPendingInvitation = true;
        IsJoined = false;
    }
    //Mutate Accepted Event
    public void Mutate(InvitationAccepted _)
    {
        HasPendingInvitation = false;
        IsJoined = true;
    }
    //Mutate Rejected Event
    public void Mutate(InvitationRejected _)
    {
        HasPendingInvitation = false;
        IsJoined = false;
    }
}
