// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.ItemAggregate;

public static class ItemExtensions
{
    public static ItemDto ToDto(this Item item)
    {
        return new ItemDto
        {
            ItemId = item.ItemId,
            Name = item.Name
        };

    }

    public async static Task<List<ItemDto>> ToDtosAsync(this IQueryable<Item> items,CancellationToken cancellationToken)
    {
        return await items.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


