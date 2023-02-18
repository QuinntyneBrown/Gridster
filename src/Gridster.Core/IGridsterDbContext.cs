// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Gridster.Core.AggregateModel.DashboardAggregate;
using Gridster.Core.AggregateModel.DashboardItemAggregate;
using Gridster.Core.AggregateModel.ItemAggregate;

namespace Gridster.Core;

public interface IGridsterDbContext
{
    DbSet<Dashboard> Dashboards { get; set; }
    DbSet<DashboardItem> DashboardItems { get; set; }
    DbSet<Item> Items { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


