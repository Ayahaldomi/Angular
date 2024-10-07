using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29_09.Server.Models;

namespace task29_09.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ProductController(MyDbContext context)
        {

        _context = context; }
        [HttpGet]
        public IActionResult get()
        {
            var services = _context.Products.ToList();
            return Ok(services);
        }
    }
}
