// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Gridster.Core;
using Gridster.Core.AggregateModel.DashboardItemAggregate;
using Gridster.Core.AggregateModel.ItemAggregate;
using Microsoft.EntityFrameworkCore;

namespace Gridster.Infrastructure.Data;

public class GridsterDbContext : DbContext, IGridsterDbContext
{
    public GridsterDbContext(DbContextOptions<GridsterDbContext> options)
        : base(options)
    {
    }

    public DbSet<Dashboard> Dashboards { get; set; }
    public DbSet<DashboardItem> DashboardItems { get; set; }
    public DbSet<Item> Items { get; set; }
}


