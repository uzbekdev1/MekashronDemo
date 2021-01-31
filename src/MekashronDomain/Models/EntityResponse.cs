using Newtonsoft.Json;

namespace MekashronDomain.Models
{
    /// <summary>
    /// Customer entity
    /// </summary>
    public class EntityResponse
    {

        public int EntityId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public int EmailConfirm { get; set; }

        public int MobileConfirm { get; set; }

        public int CountryID { get; set; }

        public int Status { get; set; }

        [JsonProperty("lid")]
        public string Lid { get; set; }

        public string FTPHost { get; set; } 

        public int FTPPort { get; set; }

    }
}
