using CleanArchitectureSample.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureSample.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class,IEntity
    {
        IQueryable<T> Entities { get; }
        List<T> GetAll();    
    }
}
