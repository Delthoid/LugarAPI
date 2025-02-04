using LugarAPI.Model;
using LugarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LugarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private LugarService _service;

        public CityController(LugarService service)
        {
            _service = service;
        }

        [HttpGet]
        public Result<City> Get([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string query = "")
        {
            if (page < 1) page = 1;

            var cities = _service.GetCities(page, limit, query);
            var result = new Result<City>()
            {
                Message = "Get Cities",
                Total = cities.Count,
                Data = cities ?? [],
            };

            return result;
        }

        [HttpGet("Barangay")]
        public Result<Barangay> GetBarangaysFromCity([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] int code = 0)
        {
            if (page < 1) page = 1;

            var barangays = _service.GetBarangaysByCityCode(page, limit, code);
            var result = new Result<Barangay>()
            {
                Message = barangays == null ? "Code not found" : "Get Cities",
                Total = barangays == null ? 0 : barangays.Count,
                Data = barangays ?? [],
            };

            return result;
        }
    }
}
