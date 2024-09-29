using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task29_09.Server.Models;

namespace task29_09.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public ServicesController(MyDbContext db)
        {
            _db = db;
        }
        ////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("getAllServices")]
        public IActionResult GetAllServices()
        {
            var services = _db.Services.ToList();
            
            return Ok(services);
        }
        ////////////////////////////////////////////////////////////////////////////////////////
    }
}
