using System;
using System.Collections.Generic;
using System.Linq;
using WebReportSolution.Entities.Orders;

namespace WebReportSolution.Entities.Interfaces
{
    public interface IOrdersRepository : IRepository<Order>
    {
        List<IGrouping<DateTime, Order>> GetDataReportOrdersAsync(DateTime fromDate, DateTime toDate);
        List<IGrouping<DateTime, Order>> GetReportOrdersAsync();
    }
}