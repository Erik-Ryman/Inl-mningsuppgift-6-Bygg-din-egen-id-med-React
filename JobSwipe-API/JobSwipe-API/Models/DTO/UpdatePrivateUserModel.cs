namespace JobSwipe_API.Models.DTO
{
    public class UpdatePrivateUserModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? AboutMe { get; set; }
        public string? Location { get; set; }
        public string? ProfilePicture { get; set; } = null;
    }
}
