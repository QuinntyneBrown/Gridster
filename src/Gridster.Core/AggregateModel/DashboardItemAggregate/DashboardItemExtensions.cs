// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardItemAggregate;

public static class DashboardItemExtensions
{
    public static DashboardItemDto ToDto(this DashboardItem dashboardItem)
    {
        return new DashboardItemDto
        {
            DashboardId = dashboardItem.DashboardId,
            Name = dashboardItem.Name,
            DashboardItemId = dashboardItem.DashboardItemId,
        };

    }

    public async static Task<List<DashboardItemDto>> ToDtosAsync(this IQueryable<DashboardItem> dashboardItems, CancellationToken cancellationToken)
    {
        return await dashboardItems.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


