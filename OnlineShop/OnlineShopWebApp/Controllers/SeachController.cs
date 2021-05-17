﻿using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class SeachController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ISeachRepository seachRepository;

        public SeachController(IProductsRepository productsRepository, ISeachRepository seachRepository)
        {
            this.productsRepository = productsRepository;
            this.seachRepository = seachRepository;
        }
        public IActionResult Index()
        {
            var seach = seachRepository.TryGetByUserId(Constants.UserId);
            return View(seach);
        }

        [HttpPost]
        public IActionResult Accept(string result)
        {
            seachRepository.Clear(Constants.UserId);
            TempData["Result"] = result;
            seachRepository.Add(productsRepository.SeachProduct(result.Split()), Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
