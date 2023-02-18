// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.ItemAggregate.Commands;

public class DeleteItemRequestValidator: AbstractValidator<DeleteItemRequest> { }

public class DeleteItemRequest: IRequest<DeleteItemResponse>
{
    public Guid ItemId { get; set; }
}


public class DeleteItemResponse: ResponseBase
{
    public ItemDto Item { get; set; }
}


public class DeleteItemRequestHandler: IRequestHandler<DeleteItemRequest,DeleteItemResponse>
{
    private readonly ILogger<DeleteItemRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public DeleteItemRequestHandler(ILogger<DeleteItemRequestHandler> logger,IGridsterDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteItemResponse> Handle(DeleteItemRequest request,CancellationToken cancellationToken)
    {
        var item = await _context.Items.FindAsync(request.ItemId);

        _context.Items.Remove(item);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Item = item.ToDto()
        };
    }

}



