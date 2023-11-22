using AutoMapper;
using CleanArchitectureDemo.Application.Common.Mappings;
using CleanArchitectureSample.Application.Interfaces;
using CleanArchitectureSample.Application.Interfaces.Repositories;
using CleanArchitectureSample.Domain.Common;
using CleanArchitectureSample.Domain.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CleanArchitectureSample.Application.Features.Trainees.Commands.CreateTrainee
{
    public record CreateTraineeCommand : IRequest<int>, IAuditableEntity
    {
        public string TraineeName { get; set; } = string.Empty;
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Id { get; set; }
    }

    internal class CreateTraineeeCommandHandler : IRequestHandler<CreateTraineeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;


        public CreateTraineeeCommandHandler(IUnitOfWork unitOfWork,IMapper mapper,ISqlConnectionFactory connectionFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sqlConnectionFactory = connectionFactory;
        }
        public async Task<int> Handle(CreateTraineeCommand request, CancellationToken cancellationToken)
        {
            var query = "INSERT INTO trainees (TraineeName,CreatedBy,UpdatedBy,CreatedDate,UpdatedDate) " +
                "VALUES (@TraineeName,@CreatedBy,@UpdatedBy,@CreatedDate,@UpdatedDate)";
            var parameters = new DynamicParameters();
            parameters.Add("TraineeName", request.TraineeName, DbType.String);
            parameters.Add("CreatedBy", request.CreatedBy, DbType.String);
            parameters.Add("UpdatedBy", request.UpdatedBy, DbType.String);
            parameters.Add("CreatedDate", DateTime.Now, DbType.DateTime);
            parameters.Add("UpdatedDate", DateTime.Now, DbType.DateTime);
            await using var connection = _sqlConnectionFactory.CreateConnection();
            var result =await connection.ExecuteAsync(query,parameters);
            return 1;
        }
    }
}
