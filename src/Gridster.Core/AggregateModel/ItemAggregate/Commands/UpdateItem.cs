// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.ItemAggregate.Commands;

public class UpdateItemRequestValidator: AbstractValidator<UpdateItemRequest> { }

public class UpdateItemRequest: IRequest<UpdateItemResponse>
{
    public Guid ItemId { get; set; }
    public string Name { get; set; }
}


public class UpdateItemResponse: ResponseBase
{
    public ItemDto Item { get; set; }
}


public class UpdateItemRequestHandler: IRequestHandler<UpdateItemRequest,UpdateItemResponse>
{
    private readonly ILogger<UpdateItemRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public UpdateItemRequestHandler(ILogger<UpdateItemRequestHandler> logger,IGridsterDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateItemResponse> Handle(UpdateItemRequest request,CancellationToken cancellationToken)
    {
        var item = await _context.Items.SingleAsync(x => x.ItemId == request.ItemId);

        item.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Item = item.ToDto()
        };

    }

}



