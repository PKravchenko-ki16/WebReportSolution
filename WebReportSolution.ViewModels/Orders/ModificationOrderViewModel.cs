using System;
using System.ComponentModel.DataAnnotations;
using WebReportSolution.ViewModels.Base;

namespace WebReportSolution.ViewModels.Orders
{
    public class ModificationOrderViewModel : DomainObjectViewModel
    {
        public override Guid Id { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}