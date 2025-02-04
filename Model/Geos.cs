using System.ComponentModel.DataAnnotations.Schema;

namespace LugarAPI.Model
{
    [Table("REGIONS")]
    public class Region : Geo
    {
    }

    [Table("PROVINCES")]
    public class Province : Geo { }
}
