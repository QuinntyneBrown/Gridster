// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardItemAggregate.Commands;

public class CreateDashboardItemRequestValidator : AbstractValidator<CreateDashboardItemRequest> { }

public class CreateDashboardItemRequest : IRequest<CreateDashboardItemResponse>
{
    public Guid DashboardId { get; set; }
    public string Name { get; set; }
    public Guid DashboardItemId { get; set; }
}


public class CreateDashboardItemResponse : ResponseBase
{
    public DashboardItemDto DashboardItem { get; set; }
}


public class CreateDashboardItemRequestHandler : IRequestHandler<CreateDashboardItemRequest, CreateDashboardItemResponse>
{
    private readonly ILogger<CreateDashboardItemRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public CreateDashboardItemRequestHandler(ILogger<CreateDashboardItemRequestHandler> logger, IGridsterDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateDashboardItemResponse> Handle(CreateDashboardItemRequest request, CancellationToken cancellationToken)
    {
        var dashboardItem = new DashboardItem();

        _context.DashboardItems.Add(dashboardItem);

        dashboardItem.DashboardId = request.DashboardId;
        dashboardItem.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            DashboardItem = dashboardItem.ToDto()
        };

    }

}



