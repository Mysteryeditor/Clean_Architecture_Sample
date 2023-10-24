using CleanArchitectureSample.Application.Interfaces.Repositories;
using CleanArchitectureSample.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Features.Trainees.Queries.GetTraineeById
{
    public record GetTraineeByIdQuery : IRequest<Trainee>
    {
        public int Id { get; set; }

        public GetTraineeByIdQuery()
        {

        }

        public GetTraineeByIdQuery(int id)
        {
            Id = id;
        }
    }
    internal class GetTraineeByIdQueryHandler : IRequestHandler<GetTraineeByIdQuery, Trainee>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetTraineeByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork =unitOfWork ;
        }

        public async Task<Trainee> Handle(GetTraineeByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Trainee>().GetById(query.Id);
            return entity;

        }
    }
}
