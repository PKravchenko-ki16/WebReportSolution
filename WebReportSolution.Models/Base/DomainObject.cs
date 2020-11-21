using System;

namespace WebReportSolution.Entities.Base
{
    public abstract class DomainObject
    {
        public abstract Guid Id { get; set; }
    }
}