using System.ComponentModel.DataAnnotations;

namespace DGCrafts.Models.ViewModels
{
    public class LoginModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
