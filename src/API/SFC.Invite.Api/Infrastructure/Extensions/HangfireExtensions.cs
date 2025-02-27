using Hangfire;
using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Infrastructure.Settings;
using SFC.Invite.Infrastructure.Extensions;
using Hangfire.Dashboard.BasicAuthorization;

namespace SFC.Invite.Api.Infrastructure.Extensions;

public static class HangfireExtensions
{
    public static void UseHangfireDashboard(this WebApplication app)
    {
        HangfireSettings settings = app.Configuration.GetHangfireSettings();

        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            DashboardTitle = settings.Dashboard.Title,
            IsReadOnlyFunc = (context) => !app.Environment.IsDevelopment(),
            Authorization = [
                new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions{
                    Users = [
                        new BasicAuthAuthorizationUser {
                            Login = settings.Dashboard.Login,
                            PasswordClear  = settings.Dashboard.Password
                        }
                    ]
                })
            ]
        });
    }
}
