using System.ComponentModel.DataAnnotations;

namespace MekashronWeb.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 6)]
        public string Password { get; set; }

    }
}