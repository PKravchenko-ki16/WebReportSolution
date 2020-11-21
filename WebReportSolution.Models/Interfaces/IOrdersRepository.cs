using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebReportSolution.Entities.Orders;

namespace WebReportSolution.Entities.Interfaces
{
    public interface IOrdersRepository : IRepository<Order>
    {
        Task<List<Order>> GetDataReportOrdersAsync(DateTime fromDate, DateTime toDate);
    }
}