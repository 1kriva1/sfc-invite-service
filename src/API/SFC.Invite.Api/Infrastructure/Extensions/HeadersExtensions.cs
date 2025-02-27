using Grpc.Core;

using SFC.Invite.Api.Infrastructure.Models.Pagination;
using SFC.Invite.Contracts.Headers;
using SFC.Invite.Infrastructure.Constants;

using System.Text.Encodings.Web;
using System.Text.Json;

namespace SFC.Invite.Api.Infrastructure.Extensions;

public static class HeadersExtensions
{
    private static readonly JsonSerializerOptions WriteOptions = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static void AddPaginationHeader(this HttpResponse response, PageMetadataModel metadata)
    {
        response?.Headers.Append(CommonConstants.PaginationHeaderKey, JsonSerializer.Serialize(metadata, WriteOptions));
    }

    public static void AddPaginationHeader(this ServerCallContext context, PaginationHeader metadata)
    {
        Metadata responseHeaders = new()
        {
            { CommonConstants.PaginationHeaderKey, JsonSerializer.Serialize(metadata, WriteOptions) }
        };
        context.WriteResponseHeadersAsync(responseHeaders);
    }

    public static void AddAuditableHeaderIfRequested(this ServerCallContext context, AuditableHeader header)
    {
        Metadata.Entry? auditableHeader = context.RequestHeaders.FirstOrDefault(h =>
            string.Equals(h.Key, CommonConstants.AuditableHeaderKey, StringComparison.OrdinalIgnoreCase));

        if (bool.TryParse(auditableHeader?.Value, out bool result) && result)
        {
            Metadata responseHeaders = new()
            {
                { CommonConstants.AuditableHeaderKey, JsonSerializer.Serialize(header, WriteOptions) }
            };

            context.WriteResponseHeadersAsync(responseHeaders);
        }
    }
}
