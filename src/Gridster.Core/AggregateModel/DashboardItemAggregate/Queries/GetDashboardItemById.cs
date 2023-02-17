// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardItemAggregate.Queries;

public class GetDashboardItemByIdRequest : IRequest<GetDashboardItemByIdResponse>
{
    public Guid DashboardItemId { get; set; }
}


public class GetDashboardItemByIdResponse : ResponseBase
{
    public DashboardItemDto DashboardItem { get; set; }
}


public class GetDashboardItemByIdRequestHandler : IRequestHandler<GetDashboardItemByIdRequest, GetDashboardItemByIdResponse>
{
    private readonly ILogger<GetDashboardItemByIdRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public GetDashboardItemByIdRequestHandler(ILogger<GetDashboardItemByIdRequestHandler> logger, IGridsterDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetDashboardItemByIdResponse> Handle(GetDashboardItemByIdRequest request, CancellationToken cancellationToken)
    {
        return new()
        {
            DashboardItem = (await _context.DashboardItems.AsNoTracking().SingleOrDefaultAsync(x => x.DashboardItemId == request.DashboardItemId)).ToDto()
        };

    }

}



