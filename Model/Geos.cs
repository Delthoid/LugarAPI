using System.ComponentModel.DataAnnotations.Schema;

namespace LugarAPI.Model
{
    [Table("REGIONS")]
    public class Region : Geo
    {
    }

    [Table("PROVINCES")]
    public class Province : Geo { }

    [Table("CITIES")]
    public class City : Geo { }

    [Table("MUNICIPALITIES")]
    public class Municipality : Geo { }

    [Table("BARANGAYS")]
    public class Barangay : Geo { }

    [Table("DISTRICTS")]
    public class Districts : Geo { }
}
