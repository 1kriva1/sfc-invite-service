using SFC.Invite.Application.Interfaces.Cache;
using SFC.Invite.Application.Interfaces.Invite.Data;
using SFC.Invite.Application.Interfaces.Invite.Data.Models;

namespace SFC.Invite.Infrastructure.Services.Cache;
public class RefreshCacheService(ICache cache, IInviteDataService inviteDataService) : IRefreshCache
{
    private readonly ICache _cache = cache;
    private readonly IInviteDataService _inviteDataService = inviteDataService;

    public async Task RefreshAsync(CancellationToken token = default)
    {
        GetAllInviteDataModel model = await _inviteDataService.GetAllInviteDataAsync().ConfigureAwait(false);
        await RefreshAsync(model.InviteStatuses, token).ConfigureAwait(false);
    }

    private Task RefreshAsync<T>(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        _cache.DeleteAsync($"{typeof(T).Name}", cancellationToken);
        return _cache.SetAsync($"{typeof(T).Name}", entities, null, cancellationToken);
    }
}