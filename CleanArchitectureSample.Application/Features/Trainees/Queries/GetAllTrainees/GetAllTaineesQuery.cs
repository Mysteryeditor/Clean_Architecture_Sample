using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace CleanArchitectureSample.Application.Features.Trainees.Queries.GetAllTrainees
{
    public record GetAllTraineesQuery : IRequest<List<Trainee>>;


    public class GetAllTraineesQueryHandler : IRequestHandler<GetAllTraineesQuery, List<Trainee>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTraineesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<Trainee>> Handle(GetAllTraineesQuery request, CancellationToken cancellationToken)
        {
            var players = await _unitOfWork.Repository<Trainee>().Entities.ToListAsync(cancellationToken);


            return players;

        }
    }
}
