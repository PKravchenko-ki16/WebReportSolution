using System;
using WebReportSolution.ViewModels.Base;

namespace WebReportSolution.ViewModels.Orders
{
    public class ModificationOrderViewModel : DomainObjectViewModel
    {
        public override Guid Id { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }
    }
}