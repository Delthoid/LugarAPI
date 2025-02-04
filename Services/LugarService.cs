using LugarAPI.Data;
using LugarAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LugarAPI.Services
{
    public class LugarService
    {
        private readonly PSGCContext _context;

        public LugarService(PSGCContext context)
        {
            _context = context;
        }

        public List<Region> GetRegions(int page, int limit)
        {
            var result =  _context.Regions
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }
    }
}
