// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Gridster.Core.AggregateModel.ItemAggregate.Commands;

public class CreateItemRequestValidator: AbstractValidator<CreateItemRequest> { }

public class CreateItemRequest: IRequest<CreateItemResponse>
{
    public string Name { get; set; }
}


public class CreateItemResponse: ResponseBase
{
    public ItemDto Item { get; set; }
}


public class CreateItemRequestHandler: IRequestHandler<CreateItemRequest,CreateItemResponse>
{
    private readonly ILogger<CreateItemRequestHandler> _logger;

    private readonly IGridsterDbContext _context;

    public CreateItemRequestHandler(ILogger<CreateItemRequestHandler> logger,IGridsterDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateItemResponse> Handle(CreateItemRequest request,CancellationToken cancellationToken)
    {
        var item = new Item();

        _context.Items.Add(item);

        item.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Item = item.ToDto()
        };

    }

}



