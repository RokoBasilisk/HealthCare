using Auth.API.Extensions;
using Auth.API.Models.Responses;
using Auth.Application.Features.Roles.Commands;
using Auth.Application.Features.Roles.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ApiResponse<CreateRoleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody][Required] CreateRoleCommand command)
            => (await _mediator.Send(command)).ToActionResult();
    }
}
