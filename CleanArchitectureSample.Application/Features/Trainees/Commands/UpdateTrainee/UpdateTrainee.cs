using CleanArchitectureSample.Application.Interfaces.Repositories;
using CleanArchitectureSample.Domain.Entities;
using MediatR;

namespace CleanArchitectureSample.Application.Features.Trainees.Commands.UpdateTrainee
{
    public record UpdateTrainee : IRequest<int>
    {
        public int? TraineeId { get; set; }
        public string? TraineeName { get; set; }

    };
    internal class UpdateTraineeHandler : IRequestHandler<UpdateTrainee, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateTraineeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateTrainee request, CancellationToken cancellationToken)
        {
            var trainee = await _unitOfWork.Repository<Trainee>().GetById(Convert.ToInt32(request.TraineeId));
            if (trainee != null)
            {
                trainee.TraineeName = request.TraineeName;

                await _unitOfWork.Repository<Trainee>().UpdateAsync(trainee);


                await _unitOfWork.Save(cancellationToken);

                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
