﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebReportSolution.BusinessLayer;
using WebReportSolution.ClientMVC.Infrastructure.Extension;
using WebReportSolution.ClientMVC.Infrastructure.Report;
using WebReportSolution.Entities.Orders;
using WebReportSolution.ViewModels.Orders;
using WebReportSolution.ViewModels.Report;

namespace WebReportSolution.ClientMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly OperationOrders _operationOrders;
        private readonly IMapper _mapper;
        private readonly GeneratingReport _generatingReport;
        private readonly FillingOutReport _fillingOutReport;

        public OrderController(OperationOrders operationOrders, IMapper mapper, GeneratingReport generatingReport, FillingOutReport fillingOutReport)
        {
            _operationOrders = operationOrders;
            _mapper = mapper;
            _generatingReport = generatingReport;
            _fillingOutReport = fillingOutReport;
        }

        public IActionResult GetReport()
        {
           return View();
        }

        [HttpPost]
        public IActionResult GetReport(ReportDatesViewModels datesViewModels)
        {
            if (datesViewModels.FromDate != default && datesViewModels.ToDate != default)
            {
                if (ModelState.IsValid)
                {
                    var ordersDateModel = _operationOrders.GetDataReportOrdersAsync(datesViewModels.FromDate, datesViewModels.ToDate);
                    if (ordersDateModel.Count != 0)
                    {
                        var exModel = _fillingOutReport.Filling(ordersDateModel);

                        DataTable table = exModel.ConvertToDataTable();
                        MemoryStream memoryStream = _generatingReport.Generating(table);
                        return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Result.xlsx");
                    }
                    ViewBag.Notification = "Orders not Found";
                    return View(datesViewModels);
                }
            }

            ModelState.Clear();
            var ordersModel = _operationOrders.GetReportOrdersAsync();
            if (ordersModel.Count != 0)
            {
                var exModel = _fillingOutReport.Filling(ordersModel);
                DataTable table = exModel.ConvertToDataTable();
                MemoryStream memoryStream = _generatingReport.Generating(table);
                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Result.xlsx");
            }
            ViewBag.Notification = "Orders not Found";
            return View();
        }

        public async Task<IActionResult> GetOrders(bool isNotFound = false)
        {
            if (isNotFound)
            {
                ViewBag.Notification = "Order not found";
            }
            var ordersModel = await _operationOrders.GetAllOrdersAsync();
            if (ordersModel != null)
            {
                var model = _mapper.Map<IEnumerable<OrderViewModel>>(ordersModel);
                return View(model);
            }
            return View();
        }

        public async Task<IActionResult> GetOrderById(Guid id)
        {
            try
            {
                var orderModel = await _operationOrders.GetByIdOrderAsync(id);
                var model = _mapper.Map<OrderViewModel>(orderModel);
                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("GetOrders", "Order", new { isNotFound = true });
            }

        }

        public async Task<IActionResult> RemoveOrder(Guid id)
        {
            try
            {
                await _operationOrders.DeleteOrder(id);
                return RedirectToAction("GetOrders", "Order");
            }
            catch (Exception e)
            {
                return RedirectToAction("GetOrders", "Order", new { isNotFound = true });
            }
        }

        public IActionResult ModificationOrder(Guid id = default)
        {
            if (id == default)
            {
                return View();
            }
            var orderModel = _operationOrders.GetByIdOrderAsync(id).Result;
            var model = _mapper.Map<ModificationOrderViewModel>(orderModel);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ModificationOrder(ModificationOrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                if (orderViewModel.Id == default)
                {
                    var orderModel = _mapper.Map<Order>(orderViewModel);

                    await _operationOrders.CreateOrder(orderModel);

                    return RedirectToAction("GetOrders", "Order");
                }
                else
                {
                    var orderModel = _mapper.Map<Order>(orderViewModel);
                    await _operationOrders.UpdateOrder(orderModel);
                    return RedirectToAction("GetOrderById", "Order", new { id = orderModel.Id });
                }
            }
            return View(orderViewModel);
        }
    }
}
