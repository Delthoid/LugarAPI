using LugarAPI.Model;
using LugarAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace LugarAPI.Controllers
{
    [EnableRateLimiting("FixedPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class BarangayController : Controller
    {
        private readonly LugarService _service;

        public BarangayController(LugarService service)
        {
            _service = service;
        }

        [HttpGet]
        public Result<Barangay> Get([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string query = "")
        {
            if (page < 1) page = 1;

            var barangays = _service.GetBarangays(page, limit, query);
            var result = new Result<Barangay>()
            {
                Message = "Get Barangays",
                Total = barangays.Count,
                Data = barangays ?? [],
            };

            return result;
        }
    }
}
