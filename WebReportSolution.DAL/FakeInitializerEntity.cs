using System;
using System.Collections.Generic;
using WebReportSolution.Entities.Orders;

namespace WebReportSolution.DAL
{
    public class FakeInitializerEntity
    {
        public static List<Order> Init()
        {
            var orders = new List<Order>
            {
                new Order(){Id = Guid.NewGuid(), Price = 1001, Date = new DateTime(2000, 01, 12)},
                new Order(){Id = Guid.NewGuid(), Price = 2001, Date = new DateTime(2001, 02, 13)},
                new Order(){Id = Guid.NewGuid(), Price = 3001, Date = new DateTime(2002, 03, 14)},
                new Order(){Id = Guid.NewGuid(), Price = 401, Date = new DateTime(2003, 04, 15)},
                new Order(){Id = Guid.NewGuid(), Price = 501, Date = new DateTime(2004, 05, 1)},
                new Order(){Id = Guid.NewGuid(), Price = 6001, Date = new DateTime(2005, 06, 17)},
            };
            return orders;
        }
    }
}