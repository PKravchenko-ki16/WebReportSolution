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
                new Order(){Id = Guid.NewGuid(), Price = 1021, Date = new DateTime(2006, 01, 11)},
                new Order(){Id = Guid.NewGuid(), Price = 101, Date = new DateTime(2007, 08, 1)},
                new Order(){Id = Guid.NewGuid(), Price = 8021, Date = new DateTime(2008, 09, 2)},
                new Order(){Id = Guid.NewGuid(), Price = 181, Date = new DateTime(2009, 10, 3)},
                new Order(){Id = Guid.NewGuid(), Price = 2001, Date = new DateTime(2010, 11, 23)},
                new Order(){Id = Guid.NewGuid(), Price = 3001, Date = new DateTime(2011, 12, 24)},
                new Order(){Id = Guid.NewGuid(), Price = 401, Date = new DateTime(2012, 01, 5)},
                new Order(){Id = Guid.NewGuid(), Price = 501, Date = new DateTime(2013, 02, 13)},
                new Order(){Id = Guid.NewGuid(), Price = 6001, Date = new DateTime(2014, 03, 1)},
                new Order(){Id = Guid.NewGuid(), Price = 1021, Date = new DateTime(2015, 04, 12)},
                new Order(){Id = Guid.NewGuid(), Price = 8021, Date = new DateTime(2016, 05, 23)},
                new Order(){Id = Guid.NewGuid(), Price = 3021, Date = new DateTime(2017, 06, 14)},
                new Order(){Id = Guid.NewGuid(), Price = 421, Date = new DateTime(2018, 07, 19)},
                new Order(){Id = Guid.NewGuid(), Price = 521, Date = new DateTime(2019, 08, 7)},
                new Order(){Id = Guid.NewGuid(), Price = 6031, Date = new DateTime(2020, 09, 27)},
            };
            return orders;
        }
    }
}