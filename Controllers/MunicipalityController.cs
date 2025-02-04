using LugarAPI.Model;
using LugarAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace LugarAPI.Controllers
{
    [EnableRateLimiting("FixedPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalityController : Controller
    {
        private readonly LugarService _service;

        public MunicipalityController(LugarService service)
        {
            _service = service;
        }

        [HttpGet]
        public Result<Municipality> Get([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string query = "")
        {
            if (page < 1) page = 1;

            var municipalities = _service.GetMunicipalities(page, limit, query);
            var result = new Result<Municipality>()
            {
                Message = "Get Regions",
                Total = municipalities.Count,
                Data = municipalities ?? [],
            };

            return result;
        }

        [HttpGet("Barangays")]
        public Result<Barangay> GetBarangays([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] int code = 0)
        {
            if (page < 1) page = 1;

            var barangays = _service.GetBarangaysByMunicipalityCode(page, limit, code);
            var result = new Result<Barangay>()
            {
                Message = barangays == null ? "Code not found" : "Get Barangays by Municipality",
                Total = barangays == null ? 0 : barangays.Count,
                Data = barangays ?? [],
            };

            return result;
        }
    }
}
