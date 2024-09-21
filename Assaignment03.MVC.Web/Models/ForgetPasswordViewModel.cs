using System.ComponentModel.DataAnnotations;

namespace Assignment06.MVC.Web.Models
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format For Email")]
        public string Email { get; set; }
    }
}
