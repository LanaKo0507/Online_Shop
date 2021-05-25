﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        public AdminController(IProductsRepository products, IOrdersRepository ordersRepository)
        {
            this.productsRepository = products;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Description(int id)
        {
            var result = productsRepository.GetProductById(id);
            return View(result);
        }
        public ActionResult EditForm(int id)
        {
            var result = productsRepository.GetProductById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult EditProduct(Product editProduct, int idCategoryItem)
        {
            var validResult = editProduct.IsValid();
            if (validResult.Count != 0)
            {
                foreach (var errors in validResult)
                {
                    ModelState.AddModelError("", errors);
                }
            }
            if (ModelState.IsValid)
            {
                productsRepository.Edit(editProduct);
                return RedirectToAction("Index", "Admin");
            }
            return View("EditForm", editProduct);
        }
        public ActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteItem(id);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewProduct(Product newProduct, int idCategoryItem)
        {
            var errorsResult = newProduct.IsValid();
            if (errorsResult.Count!=0)
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
                return View("AddProduct", newProduct);
            }
            if (ModelState.IsValid)
            {
                productsRepository.Add(newProduct);
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult OrderForm(int number)
        {
            var order = ordersRepository.GetOrderByNumber(number);
            ViewData["Statuses"] = order.InfoStatus.GetAllStatuses();
            return View(order);
        }
        public IActionResult EditOrder(int number, string status)
        {
            var order = ordersRepository.GetOrderByNumber(number);
            order.InfoStatus.ChangeStatus(status);
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteOrder(int number)
        {
            ordersRepository.Delete(number);
            return RedirectToAction("Index", "Admin");
        }
    }
}
