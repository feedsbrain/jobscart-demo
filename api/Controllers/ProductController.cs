using System.Linq;
using JobsCart.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobsCart.Controllers {

    [Authorize]
    [Route ("api/[Controller]")]
    public class ProductController : Controller {
        private readonly JobsDbContext _context;

        public ProductController (JobsDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts () {
            return Json(_context.Products.AsEnumerable());
        }
    }
    
}