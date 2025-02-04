using LugarAPI.Model;
using LugarAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LugarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : Controller
    {
        private readonly LugarService _service;

        public RegionController(LugarService service)
        {
            _service = service;
        }

        [HttpGet]
        public Result<Region> Get([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string query = "")
        {
            if (page < 1) page = 1;

            var regions = _service.GetRegions(page, limit, query);
            var result = new Result<Region>()
            {
                Message = "Get Regions",
                Total = regions.Count,
                Data = regions ?? [],
            };

            return result;
        }

        [HttpGet("Provinces")]
        public Result<Province> GetProvinces([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] int code = 0)
        {
            if (page < 1) page = 1;

            var regions = _service.GetProvincesByRegionCode(page, limit, code);
            var result = new Result<Province>()
            {
                Message = regions == null ? "Code not found" : "Get Provinces by Region",
                Total = regions == null ? 0 : regions.Count,
                Data = regions ?? [],
            };

            return result;
        }
    }
}
