using System.ComponentModel.DataAnnotations;

namespace EventManager.Models.ViewModels
{
    public class UserViewModels
    {
        public class LoginModel
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            [UIHint("password")]
            public string Password { get; set; }
            public string ReturnUrl { get; set; } = "/";
        }
        public class RegisterModel
        {
            [Required(ErrorMessage = "The User name field is required.")]
            [StringLength(255)]
            public string Username { get; set; }

            [Required(ErrorMessage = "The E-mail field is required.")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required(ErrorMessage = "The Password field is required.")]
            [DataType(DataType.Password)]
            [Compare("ConfirmPassword"/*, ErrorMessage = "Passwords must match"*/)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Password")]
            public string ConfirmPassword { get; set; }
        }
    }
}
