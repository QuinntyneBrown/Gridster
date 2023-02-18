// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.ItemAggregate.Queries;

public class GetItemByIdRequest: IRequest<GetItemByIdResponse>
{
    public Guid ItemId { get; set; }
}


public class GetItemByIdResponse: ResponseBase
{
    public ItemDto Item { get; set; }
}


public class GetItemByIdRequestHandler: IRequestHandler<GetItemByIdRequest,GetItemByIdResponse>
{
    private readonly ILogger<GetItemByIdRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public GetItemByIdRequestHandler(ILogger<GetItemByIdRequestHandler> logger,IGridsterDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetItemByIdResponse> Handle(GetItemByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Item = (await _context.Items.AsNoTracking().SingleOrDefaultAsync(x => x.ItemId == request.ItemId)).ToDto()
        };

    }

}



