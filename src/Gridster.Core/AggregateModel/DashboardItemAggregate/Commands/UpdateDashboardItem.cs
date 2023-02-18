// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardItemAggregate.Commands;

public class UpdateDashboardItemRequestValidator : AbstractValidator<UpdateDashboardItemRequest> { }

public class UpdateDashboardItemRequest : IRequest<UpdateDashboardItemResponse>
{
    public Guid DashboardItemId { get; set; }
    public Guid DashboardId { get; set; }
    public required string Name { get; set; }
}


public class UpdateDashboardItemResponse : ResponseBase
{
    public DashboardItemDto DashboardItem { get; set; }
}


public class UpdateDashboardItemRequestHandler : IRequestHandler<UpdateDashboardItemRequest, UpdateDashboardItemResponse>
{
    private readonly ILogger<UpdateDashboardItemRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public UpdateDashboardItemRequestHandler(ILogger<UpdateDashboardItemRequestHandler> logger, IGridsterDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateDashboardItemResponse> Handle(UpdateDashboardItemRequest request, CancellationToken cancellationToken)
    {
        var dashboardItem = await _context.DashboardItems.SingleAsync(x => x.DashboardItemId == request.DashboardItemId);

        dashboardItem.DashboardId = request.DashboardId;
        
        dashboardItem.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            DashboardItem = dashboardItem.ToDto()
        };

    }

}



