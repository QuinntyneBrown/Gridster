// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardAggregate;

public static class DashboardExtensions
{
    public static DashboardDto ToDto(this Dashboard dashboard)
    {
        return new DashboardDto
        {
            Name = dashboard.Name,
            DashboardId = dashboard.DashboardId,
        };

    }

    public async static Task<List<DashboardDto>> ToDtosAsync(this IQueryable<Dashboard> dashboards, CancellationToken cancellationToken)
    {
        return await dashboards.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


