using System;
using System.Collections.Generic;
using System.Linq;
using WebReportSolution.Entities.Orders;
using WebReportSolution.ViewModels.ExportReport;

namespace WebReportSolution.ClientMVC.Infrastructure.Report
{
    public class FillingOutReport
    {
        public List<ExpReportNumberOfOrdersByDate> Filling(IEnumerable<IGrouping<DateTime,Order>> groupOrders)
        {
            List<ExpReportNumberOfOrdersByDate> expReport = new List<ExpReportNumberOfOrdersByDate>();
            foreach (var orders in groupOrders)
            {
                ExpReportNumberOfOrdersByDate temp = new ExpReportNumberOfOrdersByDate{ Date = orders.Key.ToShortDateString() };
                foreach (var j in orders)
                {
                    if (j.Price <= 1000)
                    {
                        temp.AmountToOneThousand += 1;
                    }
                    else if (j.Price > 1000 && j.Price <= 5000)
                    {
                        temp.AmountToFiveThousand += 1;
                    }
                    else
                    {
                        temp.AmountFromFiveThousand += 1;
                    }
                }
                expReport.Add(temp);
            }
            return expReport;
        }
    }
}