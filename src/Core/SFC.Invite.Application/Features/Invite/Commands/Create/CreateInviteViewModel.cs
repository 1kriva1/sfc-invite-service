﻿using SFC.Invite.Application.Common.Mappings.Interfaces;
using SFC.Invite.Application.Features.Invite.Common.Dto;

namespace SFC.Invite.Application.Features.Invite.Commands.Create;
public class CreateInviteViewModel : IMapFrom<InviteEntity>
{
    public required InviteDto Invite { get; set; }
}
