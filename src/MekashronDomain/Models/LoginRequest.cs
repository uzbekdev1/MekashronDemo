namespace MekashronDomain.Models
{
    /// <summary>
    /// Login params
    /// </summary>
    public class LoginRequest
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string IPs { get; set; }

    }
}
