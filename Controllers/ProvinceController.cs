using LugarAPI.Model;
using LugarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LugarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinceController : Controller
    {
        private readonly LugarService _service;

        public ProvinceController(LugarService service)
        {
            _service = service;
        }

        [HttpGet]
        public Result<Province> Get([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string query = "")
        {
            if (page < 1) page = 1;

            var regions = _service.GetProvinces(page, limit, query);
            var result = new Result<Province>()
            {
                Message = "Get Regions",
                Total = regions.Count,
                Data = regions ?? [],
            };

            return result;
        }

        [HttpGet("Cities")]
        public Result<City> GetCities([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] int code = 0)
        {
            if (page < 1) page = 1;

            var cities = _service.GetCitiesByProvinceCode(page, limit, code);
            var result = new Result<City>()
            {
                Message = cities == null ? "Code not found" : "Get Cities by Province Code",
                Total = cities == null ? 0 : cities.Count,
                Data = cities ?? [],
            };

            return result;
        }

        [HttpGet("Municipalities")]
        public Result<Municipality> GetMunicipalities([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] int code = 0)
        {
            if (page < 1) page = 1;

            var cities = _service.GetMunicipalitiesByProvince(page, limit, code);
            var result = new Result<Municipality>()
            {
                Message = cities == null ? "Code not found" : "Get Cities by Province Code",
                Total = cities == null ? 0 : cities.Count,
                Data = cities ?? [],
            };

            return result;
        }
    }
}
