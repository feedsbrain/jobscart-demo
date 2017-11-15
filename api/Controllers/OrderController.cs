using System.Collections.Generic;
using System.Linq;
using JobsCart.DAL;
using JobsCart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobsCart.Controllers {

    [Authorize]
    [Route ("api/[Controller]")]
    public class OrderController : Controller {
        private readonly JobsDbContext _context;

        public OrderController (JobsDbContext context) {
            _context = context;
        }

        [HttpPost]
        public IActionResult CheckoutOrder ([FromBody] IEnumerable<Order> orders) {
            var result = new List<Order>();
            return Json (result);
        }
    }
    
}