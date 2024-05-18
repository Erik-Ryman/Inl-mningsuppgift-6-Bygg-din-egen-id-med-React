namespace JobSwipe_API.Models.DTO.Auth
{
    public class RefreshModel
    {
        public required string JwtToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
