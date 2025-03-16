using LugarAPI.Model;
using LugarAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace LugarAPI.Controllers
{
    [EnableRateLimiting("FixedPolicy")]
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
        public Result<Municipality> GetMunicipalities([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] int code = 0, bool includeCities = false)
        {
            if (page < 1) page = 1;

            var municipalities = _service.GetMunicipalitiesByProvince(page, limit, code);

            if (includeCities)
            {
                var cities = GetCities(page, limit, code);
                if (cities.Data.Any())
                {
                    foreach (var city in cities.Data)
                    {
                        municipalities?.Add(new Municipality()
                        {
                            Code = city.Code,
                            Name = city.Name,
                        });
                    }
                }
            }

            var result = new Result<Municipality>()
            {
                Message = municipalities == null ? "Code not found" : "Get Cities by Province Code",
                Total = municipalities == null ? 0 : municipalities.Count,
                Data = municipalities?.OrderBy(a => a.Name)?.ToList() ?? [],
            };

            return result;
        }
    }
}
