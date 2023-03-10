// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.DashboardItemAggregate;

public class DashboardItem
{
    public Guid DashboardItemId { get; set; }
    public Guid DashboardId { get; set; }
    public Guid ItemId { get; set; }
    public string Name { get; set; }

}


