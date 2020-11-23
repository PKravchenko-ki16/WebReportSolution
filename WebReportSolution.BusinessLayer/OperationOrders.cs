using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebReportSolution.DAL.Repository;
using WebReportSolution.Entities.Orders;

namespace WebReportSolution.BusinessLayer
{
    public class OperationOrders
    {
        private readonly OrdersRepository _repository;

        public OperationOrders(OrdersRepository repository)
        {
            _repository = repository;
        }

        public List<IGrouping<DateTime, Order>> GetReportOrdersAsync()
        {
            return _repository.GetReportOrdersAsync();
        }

        public List<IGrouping<DateTime, Order>> GetDataReportOrdersAsync(DateTime fromDate, DateTime toDate)
        {
            return _repository.GetDataReportOrdersAsync(fromDate, toDate);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order> GetByIdOrderAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateOrder(Order order)
        {
            try
            {
                await _repository.Create(order);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                await _repository.Save();
            }
        }

        public async Task UpdateOrder(Order order)
        {
            try
            {
                await _repository.Update(order);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                await _repository.Save();
            }
        }

        public async Task DeleteOrder(Guid id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                await _repository.Save();
            }
        }
    }
}