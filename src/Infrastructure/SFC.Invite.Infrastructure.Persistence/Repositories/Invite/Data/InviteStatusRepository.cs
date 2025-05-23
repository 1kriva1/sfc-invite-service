using SFC.Invite.Application.Interfaces.Persistence.Repository.Invite.Data;
using SFC.Invite.Domain.Entities.Invite.Data;
using SFC.Invite.Infrastructure.Persistence.Contexts;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Invite.Data;
public class InviteStatusRepository(InviteDbContext context)
    : InviteDataRepository<InviteStatus, InviteStatusEnum>(context), IInviteStatusRepository
{ }