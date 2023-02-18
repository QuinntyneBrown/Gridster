// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardAggregate.Commands;

public class UpdateDashboardRequestValidator : AbstractValidator<UpdateDashboardRequest> { }

public class UpdateDashboardRequest : IRequest<UpdateDashboardResponse>
{
    public Guid DashboardId { get; set; }
    public string Name { get; set; }
}


public class UpdateDashboardResponse : ResponseBase
{
    public DashboardDto Dashboard { get; set; }
}


public class UpdateDashboardRequestHandler : IRequestHandler<UpdateDashboardRequest, UpdateDashboardResponse>
{
    private readonly ILogger<UpdateDashboardRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public UpdateDashboardRequestHandler(ILogger<UpdateDashboardRequestHandler> logger, IGridsterDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateDashboardResponse> Handle(UpdateDashboardRequest request, CancellationToken cancellationToken)
    {
        var dashboard = await _context.Dashboards.SingleAsync(x => x.DashboardId == request.DashboardId);

        dashboard.Name = request.Name;
        dashboard.DashboardId = request.DashboardId;

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Dashboard = dashboard.ToDto()
        };

    }

}



