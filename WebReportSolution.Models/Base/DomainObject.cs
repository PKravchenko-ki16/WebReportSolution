using System;

namespace WebReportSolution.Models.Base
{
    public abstract class DomainObject
    {
        public abstract Guid Id { get; set; }
    }
}