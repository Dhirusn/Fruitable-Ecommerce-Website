using System.ComponentModel.DataAnnotations;

namespace Fruitable.ViewModels
{
    public class ConfirmEmailViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "OTP")]
        public int OTP { get; set; }

        public bool ResendOTP { get; set; } // New property for resend OTP option
    }
}
