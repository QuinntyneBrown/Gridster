// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardItemAggregate.Queries;

public class GetDashboardItemsRequest : IRequest<GetDashboardItemsResponse> { }

public class GetDashboardItemsResponse : ResponseBase
{
    public List<DashboardItemDto> DashboardItems { get; set; }
}


public class GetDashboardItemsRequestHandler : IRequestHandler<GetDashboardItemsRequest, GetDashboardItemsResponse>
{
    private readonly ILogger<GetDashboardItemsRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public GetDashboardItemsRequestHandler(ILogger<GetDashboardItemsRequestHandler> logger, IGridsterDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetDashboardItemsResponse> Handle(GetDashboardItemsRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            DashboardItems = await _context.DashboardItems.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



