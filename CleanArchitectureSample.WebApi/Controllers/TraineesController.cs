using CleanArchitectureSample.Application.Features.Trainees.Queries.GetAllTrainees;
using CleanArchitectureSample.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TraineesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trainee>>> GetTrainees()
        {
            return await _mediator.Send(new GetAllTraineesQuery());
        }
    }
}
