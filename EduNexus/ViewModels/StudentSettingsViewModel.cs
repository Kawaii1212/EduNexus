using System.ComponentModel.DataAnnotations;

namespace EduNexus.ViewModels
{
    public class StudentSettingsViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }
        
        public string? AvatarUrl { get; set; }

        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }

        public bool EmailNotifications { get; set; } = true;
        public bool SMSReminders { get; set; } = false;
    }
}
