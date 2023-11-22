using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitectureSample.Application.Interfaces;
using CleanArchitectureSample.Application.Interfaces.Repositories;
using CleanArchitectureSample.Domain.Entities;
using CleanArchitectureSample.Shared.Result;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Features.Trainees.Queries.GetAllTrainees
{
    public record GetAllTraineesQuery : IRequest<ResultModel<List<Trainee>>>;


    public class GetAllTraineesQueryHandler : IRequestHandler<GetAllTraineesQuery, ResultModel<List<Trainee>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetAllTraineesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper,ISqlConnectionFactory connectionFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _connectionFactory = connectionFactory;
        }
        public async Task<ResultModel<List<Trainee>>> Handle(GetAllTraineesQuery request, CancellationToken cancellationToken)
        {
            
            await using var sqlConnection = _connectionFactory.CreateConnection();
            var players = sqlConnection.Query<Trainee>(@"Select TraineeId,TraineeName from trainees").ToList();
            if (players is not null)
            {
                var result = Result<List<Trainee>>.ReturnResult(200, "Retrieval Success", players);
                return result;

            }
            else
            {
                var result = Result<List<Trainee>>.ReturnResult(204, "no data found", null);
                return result;

            }

           

        }
    }
}
