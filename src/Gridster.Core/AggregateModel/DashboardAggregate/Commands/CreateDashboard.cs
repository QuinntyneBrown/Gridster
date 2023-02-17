// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardAggregate.Commands;

public class CreateDashboardRequestValidator : AbstractValidator<CreateDashboardRequest> { }

public class CreateDashboardRequest : IRequest<CreateDashboardResponse>
{
    public string Name { get; set; }
    public Guid DashboardId { get; set; }
}


public class CreateDashboardResponse : ResponseBase
{
    public DashboardDto Dashboard { get; set; }
}


public class CreateDashboardRequestHandler : IRequestHandler<CreateDashboardRequest, CreateDashboardResponse>
{
    private readonly ILogger<CreateDashboardRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public CreateDashboardRequestHandler(ILogger<CreateDashboardRequestHandler> logger, IGridsterDbContext context)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateDashboardResponse> Handle(CreateDashboardRequest request, CancellationToken cancellationToken)
    {
        var dashboard = new Dashboard();

        _context.Dashboards.Add(dashboard);

        dashboard.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Dashboard = dashboard.ToDto()
        };

    }

}



