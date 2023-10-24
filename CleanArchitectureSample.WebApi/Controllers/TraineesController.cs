using CleanArchitectureSample.Application.Features.Trainees.Commands.CreateTrainee;
using CleanArchitectureSample.Application.Features.Trainees.Commands.UpdateTrainee;
using CleanArchitectureSample.Application.Features.Trainees.Queries.GetAllTrainees;
using CleanArchitectureSample.Application.Features.Trainees.Queries.GetTraineeById;
using CleanArchitectureSample.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureSample.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public async Task<ActionResult<Trainee>> GetTraineeById(int id)
        {
            return await _mediator.Send(new GetTraineeByIdQuery(id));
        }

        [HttpPost]
        public async Task<int> PostTrainee(CreateTraineeCommand trainee)
        {
            return (int)await _mediator.Send(trainee); 
        }

        [HttpPut]
        public async Task<int> PutTrainee(int? TraineeId,UpdateTrainee trainee)
        {
            if (TraineeId is not null)
            {
                trainee.TraineeId = TraineeId;
            }
            return (int)await _mediator.Send(trainee);
        }
    }
}
