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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
    {
        private readonly TraineeDbContext _traineeContext;
        public GenericRepository(TraineeDbContext dbContext)
        {
            _traineeContext = dbContext;
        }

        public IQueryable<T> Entities => _traineeContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _traineeContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _traineeContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _traineeContext.Set<T>().FindAsync(id);
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _traineeContext.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync(T entity)
        {
            //T exist = _traineeContext.Set<T>().Find(entity.Id);
            //_traineeContext.Entry(exist).CurrentValues.SetValues(entity);
            _traineeContext.Entry(entity).State= EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
