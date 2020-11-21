﻿using System;
using WebReportSolution.ViewModels.Base;

namespace WebReportSolution.ViewModels.Orders
{
    public class OrderViewModel : DomainObjectViewModel
    {
        public override Guid Id { get; set; }

        public int Price { get; set; }

        public string Date { get; set; }
    }
}