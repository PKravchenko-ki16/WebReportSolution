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
                new Order(){Id = Guid.NewGuid(), Price = 1001, Date = new DateTime(2018, 07, 19)},
                new Order(){Id = Guid.NewGuid(), Price = 2001, Date = new DateTime(2018, 07, 19)},
                new Order(){Id = Guid.NewGuid(), Price = 3001, Date = new DateTime(2018, 07, 19)},
                new Order(){Id = Guid.NewGuid(), Price = 401, Date = new DateTime(2018, 07, 19)},
                new Order(){Id = Guid.NewGuid(), Price = 501, Date = new DateTime(2018, 07, 19)},
                new Order(){Id = Guid.NewGuid(), Price = 6001, Date = new DateTime(2019, 08, 7)},
                new Order(){Id = Guid.NewGuid(), Price = 1021, Date = new DateTime(2019, 08, 7)},
                new Order(){Id = Guid.NewGuid(), Price = 101, Date = new DateTime(2019, 08, 7)},
                new Order(){Id = Guid.NewGuid(), Price = 8021, Date = new DateTime(2019, 08, 7)},
                new Order(){Id = Guid.NewGuid(), Price = 181, Date = new DateTime(2019, 08, 7)},
                new Order(){Id = Guid.NewGuid(), Price = 2001, Date = new DateTime(2020, 09, 27)},
                new Order(){Id = Guid.NewGuid(), Price = 3001, Date = new DateTime(2020, 09, 27)},
                new Order(){Id = Guid.NewGuid(), Price = 401, Date = new DateTime(2020, 09, 27)},
                new Order(){Id = Guid.NewGuid(), Price = 501, Date = new DateTime(2020, 09, 27)},
                new Order(){Id = Guid.NewGuid(), Price = 6001, Date = new DateTime(2020, 09, 27)},
                new Order(){Id = Guid.NewGuid(), Price = 1021, Date = new DateTime(2017, 06, 14)},
                new Order(){Id = Guid.NewGuid(), Price = 8021, Date = new DateTime(2017, 06, 14)},
                new Order(){Id = Guid.NewGuid(), Price = 3021, Date = new DateTime(2017, 06, 14)},
                new Order(){Id = Guid.NewGuid(), Price = 421, Date = new DateTime(2018, 07, 19)},
                new Order(){Id = Guid.NewGuid(), Price = 521, Date = new DateTime(2019, 08, 7)},
                new Order(){Id = Guid.NewGuid(), Price = 6031, Date = new DateTime(2020, 09, 27)},
            };
            return orders;
        }
    }
}