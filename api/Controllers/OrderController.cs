using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
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
        private IMapper _mapper;

        public OrderController(ICheckoutService checkoutService, IMapper mapper)
        {
            _checkoutService = checkoutService;
            _mapper = mapper;
        }

        [HttpPost("checkout")]
        public IActionResult Checkout([FromBody] OrderDto order)
        {
            // Currently just use UserName for simplicity
            order.CustomerId = User.FindFirst(ClaimTypes.Name).Value;
            var result = _mapper.Map<CheckoutDto>(_checkoutService.Checkout(order));
            return Json(result);
        }
    }

}