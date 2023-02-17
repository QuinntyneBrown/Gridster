// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardItemAggregate.Commands;

public class DeleteDashboardItemRequestValidator : AbstractValidator<DeleteDashboardItemRequest> { }

public class DeleteDashboardItemRequest : IRequest<DeleteDashboardItemResponse>
{
    public Guid DashboardItemId { get; set; }
}


public class DeleteDashboardItemResponse : ResponseBase
{
    public DashboardItemDto DashboardItem { get; set; }
}


public class DeleteDashboardItemRequestHandler : IRequestHandler<DeleteDashboardItemRequest, DeleteDashboardItemResponse>
{
    private readonly ILogger<DeleteDashboardItemRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public DeleteDashboardItemRequestHandler(ILogger<DeleteDashboardItemRequestHandler> logger, IGridsterDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteDashboardItemResponse> Handle(DeleteDashboardItemRequest request, CancellationToken cancellationToken)
    {
        var dashboardItem = await _context.DashboardItems.FindAsync(request.DashboardItemId);

        _context.DashboardItems.Remove(dashboardItem);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            DashboardItem = dashboardItem.ToDto()
        };
    }

}



