using LugarAPI.Data;
using LugarAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Runtime.InteropServices.Marshalling;

namespace LugarAPI.Services
{
    //TODO: Add search query
    public class LugarService
    {
        private readonly PSGCContext _context;

        public LugarService(PSGCContext context)
        {
            _context = context;
        }

        #region Regions

        public List<Region> GetRegions(int page, int limit, string query)
        {
            var result =  _context.Regions
                .Where(c => string.IsNullOrEmpty(query) ? true : c.Name.ToLower().Contains(query.ToLower()))
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }

        /// <summary>
        /// The first two digits from code will be extracted. Since the first two digits indicates the Region Code
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Province>? GetProvincesByRegionCode(int page, int limit, int code)
        {
            if (code <= 0) return null;

            var region = _context.Regions
                .Where(r => r.Code == code)
                .SingleOrDefault();

            if (region == null) return null;

            var regionCode = code.ToString().Substring(0, 2);
            var result = _context.Provinces
                .Where(p => p.Code.ToString().Substring(0, 2) == regionCode)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }

        #endregion

        #region Provinces
        public List<Province> GetProvinces(int page, int limit, string query)
        {
            var result = _context.Provinces
                .Where(c => string.IsNullOrEmpty(query) ? true : c.Name.ToLower().Contains(query.ToLower()))
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }

        public List<City>? GetCitiesByProvinceCode(int page, int limit, int code)
        {
            if (code <= 0) return null;

            var province = _context.Provinces
                .Where(r => r.Code == code)
                .SingleOrDefault();

            //Check if the code is belongs to NCR. Since NCR does not have any provinces. We will return the cities under by NCR code then
            if (province == null)
            {
                var ncr = _context.Regions
                    .Where(r => r.Code == code)
                    .SingleOrDefault();

                if (ncr != null)
                {
                    return _context.Cities
                        .Where(c => c.Code.ToString().Substring(0, 2) == ncr.Code.ToString().Substring(0, 2))
                        .ToList();
                }
            }

            if (province == null) return null;

            var provinceCode = code.ToString().Substring(0, 5);
            var result = _context.Cities
                .Where(c => c.Code.ToString().Substring(0, 5) == provinceCode)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }

        public List<Municipality>? GetMunicipalitiesByProvince(int page, int limit, int code)
        {
            if (code <= 0) return null;

            var province = _context.Provinces
                .Where(r => r.Code == code)
                .SingleOrDefault();

            //Check if the code is belongs to NCR. Since NCR does not have any provinces. We will return the cities under by NCR code then
            if (province == null)
            {
                var ncr = _context.Regions
                    .Where(r => r.Code == code)
                    .SingleOrDefault();

                if (ncr != null)
                {
                    return _context.Municipalities
                        .Where(c => c.Code.ToString().Substring(0, 2) == ncr.Code.ToString().Substring(0, 2))
                        .ToList();
                }
            }

            if (province == null) return null;

            var provinceCode = code.ToString().Substring(0, 5);
            var result = _context.Municipalities
                .Where(c => c.Code.ToString().Substring(0, 5) == provinceCode)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }
        #endregion

        #region Cities
        public List<City> GetCities(int page, int limit, string query = "")
        {
            var result = _context.Cities
                .Where(c => string.IsNullOrEmpty(query) ? true : c.Name.ToLower().Contains(query.ToLower()))
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }

        public List<Barangay>? GetBarangaysByCityCode(int page, int limit, int code)
        {
            if (code <= 0) return null;

            var region = _context.Cities
                .Where(r => r.Code == code)
                .SingleOrDefault();

            if (region == null) return null;
            var cityCode = code.ToString().Substring(0, 7);
            var result = _context.Barangays
                .Where(b => b.Code.ToString().Substring(0, 7) == cityCode)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();

            return result;
        }
        #endregion

        #region Municipalities
        public List<Municipality> GetMunicipalities(int page, int limit, string query = "")
        {
            var result = _context.Municipalities
                .Where(m => string.IsNullOrEmpty(query) ? true : m.Name.ToLower().Contains(query.ToLower()))
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }

        public List<Barangay>? GetBarangaysByMunicipalityCode(int page, int limit, int code)
        {
            if (code <= 0) return null;

            var municipality = _context.Municipalities
                .Where(r => r.Code == code)
                .SingleOrDefault();

            if (municipality == null) return null;
            var municipalityCode = code.ToString().Substring(0, 7);
            var result = _context.Barangays
                .Where(b => b.Code.ToString().Substring(0, 7) == municipalityCode)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();

            return result;
        }
        #endregion

        #region Districts
        public List<Districts> GetDistricts(int page, int limit, string query)
        {
            var result = _context.Districts
                .Where(m => string.IsNullOrEmpty(query) ? true : m.Name.ToLower().Contains(query.ToLower()))
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToList();
            return result;
        }
        #endregion
    }
}
