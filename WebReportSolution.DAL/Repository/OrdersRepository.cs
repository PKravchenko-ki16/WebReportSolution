using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebReportSolution.Models.Interfaces;
using WebReportSolution.Models.Orders;

namespace WebReportSolution.DAL.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationContext _context;

        public OrdersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.Select(x => x).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public Task Create(Order order)
        {
            _context.Orders.Add(order);
            Save();
            return Task.CompletedTask;
        }

        public Task Update(Order order)
        {
            _context.Orders.Update(order);
            Save();
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            Order order = GetByIdAsync(id).Result;
            _context.Orders.Attach(order);
            _context.Orders.Remove(order);
            Save();
            return Task.CompletedTask;
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}