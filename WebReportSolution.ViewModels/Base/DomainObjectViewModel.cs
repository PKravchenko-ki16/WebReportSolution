using System;

namespace WebReportSolution.ViewModels.Base
{
    public abstract class DomainObjectViewModel
    {
        public abstract Guid Id { get; set; }
    }
}