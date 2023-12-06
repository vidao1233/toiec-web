namespace toiec_web.ViewModels.Authentication
{
    public class UpdateProfileModel
    {
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool Enable2FA { get; set; }
        public IFormFile? ImageURL { get; set; }
    }
}
