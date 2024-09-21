using System.ComponentModel.DataAnnotations;

namespace Assignment06.MVC.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name Is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage ="Invalid Format For Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{6,}$", ErrorMessage = "Password must be at least 6 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password Is Required")]
        [Compare(nameof(Password),ErrorMessage = "Confirm Password Doesn't Match Password")]
        public string ConfirmPassword { get; set; }
       [Required(ErrorMessage = "Required To Agree ")]
        public bool IsAgree { get; set; }
    }
}
