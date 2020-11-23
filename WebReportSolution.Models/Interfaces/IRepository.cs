using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebReportSolution.Entities.Base;

namespace WebReportSolution.Entities.Interfaces
{
    public interface IRepository<T>
        where T : DomainObject, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task Create(T obj);
        Task Update(T obj);
        Task Delete(Guid id);
        Task Save();
    }
}