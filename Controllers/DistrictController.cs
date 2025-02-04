using LugarAPI.Model;
using LugarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LugarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistrictController : Controller
    {
        private readonly LugarService _service;

        public DistrictController(LugarService service) 
        { 
            _service = service;
        }

        [HttpGet]
        public Result<Districts> Get([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string query = "")
        {
            if (page < 1) page = 1;

            var districts = _service.GetDistricts(page, limit, query);
            var result = new Result<Districts>()
            {
                Message = "Get Districts",
                Total = districts.Count,
                Data = districts ?? [],
            };

            return result;
        }
    }
}
