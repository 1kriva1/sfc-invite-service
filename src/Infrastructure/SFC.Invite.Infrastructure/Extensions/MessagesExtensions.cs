using AutoMapper;

using SFC.Invite.Application.Interfaces.Invite.Data.Models;
using SFC.Invite.Messages.Commands.Common;
using SFC.Invite.Messages.Events.Invite.Data;

using InviteDataValue = SFC.Invite.Messages.Models.Data.DataValue;
using TeamDataValue = SFC.Team.Messages.Models.Data.DataValue;
using TeamInitializeData = SFC.Team.Messages.Commands.Invite.Data.InitializeData;

namespace SFC.Invite.Infrastructure.Extensions;
public static class MessagesExtensions
{
    public static DataInitialized BuildInviteDataInitializedEvent(this IMapper mapper, GetAllInviteDataModel model)
    {
        DataInitialized message = new()
        {
            InviteStatuses = mapper.Map<IEnumerable<InviteDataValue>>(model.InviteStatuses)
        };

        return message;
    }

    public static TeamInitializeData BuildInitializeDataCommand(this IMapper mapper, GetTeamDataModel model)
    {
        TeamInitializeData message = new()
        {
            InviteStatuses = mapper.Map<IEnumerable<TeamDataValue>>(model.InviteStatuses)
        };

        return message;
    }

    public static T SetCommandInitiator<T>(this T command, string initiator) where T : InitiatorCommand
    {
        command.Initiator = initiator;
        return command;
    }
}