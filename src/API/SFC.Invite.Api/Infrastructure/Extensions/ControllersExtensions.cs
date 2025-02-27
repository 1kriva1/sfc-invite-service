using Microsoft.AspNetCore.Mvc;

using SFC.Invite.Api.Infrastructure.Extensions;
using SFC.Invite.Api.Infrastructure.Models.Base;
using SFC.Invite.Application;
using SFC.Invite.Infrastructure.Constants;
using SFC.Invite.Api.Infrastructure.Filters;

namespace SFC.Invite.Api.Infrastructure.Extensions;

public static class ControllersExtensions
{
    public static void AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers(configure =>
        {
            configure.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

            // Return 406 when Accept is not application/json
            configure.ReturnHttpNotAcceptable = true;

            // Accept and Content-Type headers filters
            configure.Filters.Add(new ProducesAttribute(CommonConstants.ContentType));
            configure.Filters.Add(new ConsumesAttribute(CommonConstants.ContentType));

            // Global responses filters
            configure.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
            configure.Filters.Add(new ProducesResponseTypeAttribute(typeof(BaseResponse), StatusCodes.Status500InternalServerError));

            configure.Filters.Add(new ValidationFilterAttribute());
        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            options.JsonSerializerOptions.WriteIndented = true;
        })
        .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
        .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(Resources)));
    }
}
