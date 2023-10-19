using CleanArchitectureSample.Application.Interfaces;
using CleanArchitectureSample.Domain.Common;
using CleanArchitectureSample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T:BaseAuditableEntity
    {
        private readonly TraineeDbContext _traineeContext;
        public GenericRepository(TraineeDbContext dbContext)
        {
            _traineeContext = dbContext;
        }

        public IQueryable<T> Entities => _traineeContext.Set<T>();

        public List<T> GetAll()
        {
            return _traineeContext.Set<T>().ToList();
        }
    }
}
