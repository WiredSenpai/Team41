using System.ComponentModel.DataAnnotations;

namespace Group41_Wired_Martians.Models
{
	public class RegisterViewModel
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Email")]
		public string? Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string? Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string? ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Profile")]
        public string? ImgUrl { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string? Status { get; set; } = "Active";

        [Required]
        [Display(Name = "CreateTime")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Role")]
        public string? Role { get; set; }
        
    }
}
