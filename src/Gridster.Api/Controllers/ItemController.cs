// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Gridster.Core.AggregateModel.ItemAggregate.Commands;
using Gridster.Core.AggregateModel.ItemAggregate.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Net.Mime;

namespace Gridster.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class ItemController
{
    private readonly IMediator _mediator;

    private readonly ILogger<ItemController> _logger;

    public ItemController(IMediator mediator,ILogger<ItemController> logger){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update Item",
        Description = @"Update Item"
    )]
    [HttpPut(Name = "updateItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateItemResponse>> Update([FromBody]UpdateItemRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create Item",
        Description = @"Create Item"
    )]
    [HttpPost(Name = "createItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateItemResponse>> Create([FromBody]CreateItemRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Items",
        Description = @"Get Items"
    )]
    [HttpGet(Name = "getItems")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetItemsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetItemsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetItemsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Item by id",
        Description = @"Get Item by id"
    )]
    [HttpGet("{itemId:guid}", Name = "getItemById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetItemByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetItemByIdResponse>> GetById([FromRoute]Guid itemId,CancellationToken cancellationToken)
    {
        var request = new GetItemByIdRequest(){ItemId = itemId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.Item == null)
        {
            return new NotFoundObjectResult(request.ItemId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete Item",
        Description = @"Delete Item"
    )]
    [HttpDelete("{itemId:guid}", Name = "deleteItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteItemResponse>> Delete([FromRoute]Guid itemId,CancellationToken cancellationToken)
    {
        var request = new DeleteItemRequest() {ItemId = itemId };

        return await _mediator.Send(request, cancellationToken);
    }

}


