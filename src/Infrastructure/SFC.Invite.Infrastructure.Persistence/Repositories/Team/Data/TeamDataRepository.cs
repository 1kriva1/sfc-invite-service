using SFC.Invite.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Invite.Domain.Common;
using SFC.Invite.Infrastructure.Persistence.Contexts;
using SFC.Invite.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamDataRepository<TEntity, TEnum>(TeamDbContext context)
    : DataRepository<TEntity, TeamDbContext, TEnum>(context), ITeamDataRepository<TEntity, TEnum>
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }