﻿using SFC.Invite.Api.Infrastructure.Models.Pagination;
using SFC.Invite.Application.Interfaces.Common;

namespace SFC.Invite.Api.Infrastructure.Extensions;
public static class PaginationExtensions
{
    public static PageMetadataModel SetLinks(this PageMetadataModel metadata, IUriService uriService, string queryString, string route)
    {
        metadata.Links = new PageLinksModel
        {
            FirstPage = uriService.GetPageUri(queryString, route, 1),
            LastPage = uriService.GetPageUri(queryString, route, metadata.TotalPages),
            NextPage = metadata.HasNextPage
                ? uriService.GetPageUri(queryString, route, metadata.CurrentPage + 1)
                : null,
            PreviousPage = metadata.HasPreviousPage
                ? uriService.GetPageUri(queryString, route, metadata.CurrentPage - 1)
                : null
        };

        return metadata;
    }
}
