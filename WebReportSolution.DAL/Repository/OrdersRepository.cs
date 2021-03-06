﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebReportSolution.Entities.Interfaces;
using WebReportSolution.Entities.Orders;

namespace WebReportSolution.DAL.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationContext _context;

        public OrdersRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<IGrouping<DateTime, Order>> GetDataReportOrdersAsync(DateTime fromDate, DateTime toDate)
        {
            return _context.Orders.Where(x => x.Date >= fromDate && x.Date <= toDate).AsEnumerable().GroupBy(x => x.Date).Select(x => x).ToList();
        }

        public List<IGrouping<DateTime, Order>> GetReportOrdersAsync()
        {
            return (_context.Orders.AsEnumerable() ?? throw new InvalidOperationException()).GroupBy(x => x.Date).Select(x => x).ToList();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders.Select(x => x).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            var order = await _context.Orders.Where(x => x.Id == id).SingleOrDefaultAsync();
            if (order == null) throw new ArgumentException(nameof(order));
            return order;
        }

        public async Task Create(Order order)
        {
            _context.Orders.Add(order);
            await Save();
        }

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await Save();
        }

        public async Task Delete(Guid id)
        {
            Order order = GetByIdAsync(id).Result ?? throw new ArgumentException(nameof(order));
            _context.Orders.Attach(order);
            _context.Orders.Remove(order);
            await Save();
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
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