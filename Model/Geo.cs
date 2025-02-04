using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace LugarAPI.Model
{
    public abstract class Geo
    {
        [DisplayName("PSGC Code")]
        public int Code { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Geographic Level")]
        [Column("GEO_LEVEL")]
        public string GeoLevel { get; set; }

        [DisplayName("Old Names")]
        [Column("OLD_NAMES")]
        public string? OldNames { get; set; }

        [DisplayName("City Class")]
        [Column("CITY_CLASS")]
        public string? CityClass { get; set; }

        [DisplayName("Income Classification")]
        [Column("INCOME_CLASSIFICATION")]
        public string? IncomeClassification { get; set; }

        [DisplayName("Urban or Rural")]
        [Column("URBAN_RURAL")]
        public string? UrbanOrRural { get; set; }
    }
}
