// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Gridster.Core.AggregateModel.DashboardItemAggregate.Commands;
using Gridster.Core.AggregateModel.DashboardItemAggregate.Queries;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace Gridster.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class DashboardItemController
{
    private readonly IMediator _mediator;

    private readonly ILogger<DashboardItemController> _logger;

    public DashboardItemController(IMediator mediator, ILogger<DashboardItemController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update DashboardItem",
        Description = @"Update DashboardItem"
    )]
    [HttpPut(Name = "updateDashboardItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateDashboardItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateDashboardItemResponse>> Update([FromBody] UpdateDashboardItemRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create DashboardItem",
        Description = @"Create DashboardItem"
    )]
    [HttpPost(Name = "createDashboardItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateDashboardItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateDashboardItemResponse>> Create([FromBody] CreateDashboardItemRequest request, CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get DashboardItems",
        Description = @"Get DashboardItems"
    )]
    [HttpGet(Name = "getDashboardItems")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDashboardItemsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDashboardItemsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetDashboardItemsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get DashboardItem  by id",
        Description = @"Get DashboardItem by id"
    )]
    [HttpGet("{dashboardItemId:guid}", Name = "getDashboardItemById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetDashboardItemByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetDashboardItemByIdResponse>> GetById([FromRoute] Guid dashboardItemId, CancellationToken cancellationToken)
    {
        var request = new GetDashboardItemByIdRequest() { DashboardItemId = dashboardItemId };

        var response = await _mediator.Send(request, cancellationToken);

        if (response.DashboardItem == null)
        {
            return new NotFoundObjectResult(request.DashboardItemId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete DashboardItem",
        Description = @"Delete DashboardItem"
    )]
    [HttpDelete("{dashboardItemId:guid}", Name = "deleteDashboardItem")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteDashboardItemResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteDashboardItemResponse>> Delete([FromRoute] Guid dashboardItemId, CancellationToken cancellationToken)
    {
        var request = new DeleteDashboardItemRequest() { DashboardItemId = dashboardItemId };

        return await _mediator.Send(request, cancellationToken);
    }

}


