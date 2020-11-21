using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebReportSolution.BusinessLayer;
using WebReportSolution.ViewModels.Orders;

namespace WebReportSolution.ClientMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly OperationOrders _operationOrders;
        private readonly IMapper _mapper;

        public OrderController(OperationOrders operationOrders, IMapper mapper)
        {
            _operationOrders = operationOrders;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetOrders()
        {
            var ordersModel = await _operationOrders.GetAllOrdersAsync();
            if (ordersModel != null)
            {
                var model = _mapper.Map<IEnumerable<OrderViewModel>>(ordersModel);
                return View(model);
            }
            return View();
        }

        public IActionResult GetOrderById(Guid id)
        {
            var filmModel = _operationOrders.GetByIdOrderAsync(id).Result;
            var model = _mapper.Map<OrderViewModel>(filmModel);
            return View(model);
        }
    }
}
