using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebReportSolution.Models.Base;

namespace WebReportSolution.Models.Interfaces
{
    public interface IRepository<T>
        where T : DomainObject, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task Create(T obj);
        Task Update(T obj);
        Task Delete(Guid id);
        void Save();
    }
}