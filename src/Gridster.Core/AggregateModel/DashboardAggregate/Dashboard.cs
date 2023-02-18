// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Gridster.Core.AggregateModel.DashboardItemAggregate;

namespace Gridster.Core.AggregateModel.DashboardAggregate;

public class Dashboard
{
    public Dashboard()
    {
        DashboardItems = new List<DashboardItem>();
    }
    public Guid DashboardId { get; set; }
    public string Name { get; set; }
    public List<DashboardItem> DashboardItems { get; set; }
}


