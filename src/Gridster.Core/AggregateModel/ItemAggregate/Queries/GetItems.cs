// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.ItemAggregate.Queries;

public class GetItemsRequest: IRequest<GetItemsResponse> { }

public class GetItemsResponse: ResponseBase
{
    public List<ItemDto> Items { get; set; }
}


public class GetItemsRequestHandler: IRequestHandler<GetItemsRequest,GetItemsResponse>
{
    private readonly ILogger<GetItemsRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public GetItemsRequestHandler(ILogger<GetItemsRequestHandler> logger,IGridsterDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetItemsResponse> Handle(GetItemsRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Items = await _context.Items.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



