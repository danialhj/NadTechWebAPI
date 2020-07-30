using Microsoft.SqlServer.Server;

namespace NadTechWebAPI.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string Postcode { get; set; }
        public int HouseNumber { get; set; }
    }
}