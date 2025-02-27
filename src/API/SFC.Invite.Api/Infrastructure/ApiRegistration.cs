using Microsoft.AspNetCore.Mvc;

using System.Reflection;

namespace SFC.Invite.Api.Infrastructure;

public static class ApiRegistration
{
    public static void AddApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        builder.Services.Configure<MvcOptions>(options => options.AllowEmptyInputInBodyModelBinding = true);
        builder.Services.AddCors();
    }
}
