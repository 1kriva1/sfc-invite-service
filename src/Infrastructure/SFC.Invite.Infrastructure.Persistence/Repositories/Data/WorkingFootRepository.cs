﻿using SFC.Invite.Application.Interfaces.Persistence.Repository.Data;
using SFC.Invite.Domain.Entities.Data;
using SFC.Invite.Infrastructure.Persistence.Contexts;

namespace SFC.Invite.Infrastructure.Persistence.Repositories.Data;
public class WorkingFootRepository(DataDbContext context)
    : DataRepository<WorkingFoot, WorkingFootEnum>(context), IWorkingFootRepository
{ }
