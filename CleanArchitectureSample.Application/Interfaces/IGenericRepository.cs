using CleanArchitectureSample.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        IQueryable<T> Entities { get; }
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> AddAsync(T entity);
        Task<int> Save(CancellationToken cancellationToken);
        Task UpdateAsync(T entity);
    }
}
