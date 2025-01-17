﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.ModelsDto;
using OnlineShop.Db.Models.Interfaces;
using OnlineShopWebApp.Helpers;
using ModelsLibrary.ModelsVM;
using System;
using System.Linq;
using System.Threading.Tasks;
using Nelibur.ObjectMapper;

namespace OnlineShopWebApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly UserManager<User> userManager;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersWithoutUserRepository, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.cartsRepository = cartsRepository;
            ordersRepository = ordersWithoutUserRepository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var userId = Request.Cookies["id"];
            var cart = await cartsRepository.GetByIdAsync(null, user.UserName ?? userId);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AcceptAsync(string Comment, UserContactViewModel userContacts)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var errorsResult = userContacts.IsValid();
            if (errorsResult != null && errorsResult.Any())
            {
                foreach (var error in errorsResult)
                {
                    ModelState.AddModelError("", error);
                }
            }
            if (ModelState.IsValid)
            {
                var order = new OrderViewModel();
                order.AddContacts(user.UserName, userContacts, new InfoStatusOrderViewModel(DateTime.Now), Comment);
                var cart = await cartsRepository.GetByIdAsync(null, user.UserName ?? Request.Cookies["id"]);
                Response.Cookies.Delete("id");
                order.Products = cart.Items.Select(TinyMapper.Map<CartItemViewModel>).ToList();
                order.Number = await ordersRepository.GetCountAsync();
                await ordersRepository.AddAsync(cart.Id, user.Id);
                return RedirectToAction("Result");
            }
            return View("Index");
        }

        public async Task<IActionResult> ResultAsync()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var order = await ordersRepository.GetLast(user.Id);
            return View(order.ToOrderViewModels());
        }
    }
}
