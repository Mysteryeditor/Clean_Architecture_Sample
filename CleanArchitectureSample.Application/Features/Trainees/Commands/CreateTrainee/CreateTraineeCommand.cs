using AutoMapper;
using CleanArchitectureDemo.Application.Common.Mappings;
using CleanArchitectureSample.Application.Interfaces.Repositories;
using CleanArchitectureSample.Domain.Common;
using CleanArchitectureSample.Domain.Common.Interfaces;
using CleanArchitectureSample.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
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


        public CreateTraineeeCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        public async Task<int> Handle(CreateTraineeCommand request, CancellationToken cancellationToken)
        {
            var newTrainee = new Trainee()
            {
                TraineeName = request.TraineeName,
                CreatedBy = request.CreatedBy,
                CreatedDate = DateTime.Now,
                UpdatedBy = request.UpdatedBy,
                UpdatedDate = DateTime.Now,
                Id = request.Id,


            };


            await _unitOfWork.Repository<Trainee>().AddAsync(newTrainee);
            await _unitOfWork.Save(cancellationToken);
            return newTrainee.Id;
        }
    }
}
