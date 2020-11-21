using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Order> GetByIdOrderAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task CreateOrder(Order order)
        {
            try
            {
                return _repository.Create(order);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                _repository.Save();
            }
        }

        public Task UpdateOrder(Order order)
        {
            try
            {
                return _repository.Update(order);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                _repository.Save();
            }
        }

        public Task DeleteOrder(Guid id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                _repository.Save();
            }
        }
    }
}