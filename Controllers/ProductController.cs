using System.Linq;
using JobsCart.DAL;
using Microsoft.AspNetCore.Mvc;

namespace JobsCart.Controllers {

    [Route ("api/[Controller]")]
    public class ProductController : Controller {
        private readonly JobsDbContext _context;

        public ProductController (JobsDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts () {
            return Json (_context.Products.AsEnumerable ());
        }
    }
    
}