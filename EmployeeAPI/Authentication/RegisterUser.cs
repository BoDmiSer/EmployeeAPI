using System.ComponentModel.DataAnnotations;


namespace EmployeeAPI.Authentication
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "LoginNameRequired")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "EmailAddressRequired")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordRequired")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPasswordRequired")]
        [Compare ("Password", ErrorMessage = "PasswordCompare")]
        [Display(Name = "ConfirmPassword")]
        public string ConfirmPassword { get; set; }
    }
}
