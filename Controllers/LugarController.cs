using LugarAPI.Model;
using LugarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LugarAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LugarController : Controller
    {
        private readonly LugarService _service;

        public LugarController(LugarService service)
        {
            _service = service;
        }

        [HttpGet]
        public Result<Region> Get([FromQuery] int page = 1, [FromQuery] int limit = 100)
        {
            if (page < 1) page = 1;

            var regions = _service.GetRegions(page, limit);
            var result = new Result<Region>()
            {
                Message = "Get Regions",
                Total = regions.Count,
                Data = regions ?? [],
            };

            return result;
        }
    }
}
