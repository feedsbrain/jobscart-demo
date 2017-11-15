using System.Collections.Generic;
using System.Linq;
using JobsCart.DAL;
using JobsCart.DTOs;
using JobsCart.Helpers;
using JobsCart.Models;
using JobsCart.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobsCart.Controllers
{

    [Authorize]
    [Route("api/[Controller]")]
    public class OrderController : Controller
    {
        private ICheckoutService _checkoutService;

        public OrderController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost]
        public IActionResult Checkout([FromBody] OrderDto order)
        {
            var result = _checkoutService.Checkout(order);
            return Json(result);
        }
    }

}