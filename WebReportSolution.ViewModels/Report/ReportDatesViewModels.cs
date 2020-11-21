using System;
using System.ComponentModel.DataAnnotations;

namespace WebReportSolution.ViewModels.Report
{
    public class ReportDatesViewModels
    {
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; }
    }
}