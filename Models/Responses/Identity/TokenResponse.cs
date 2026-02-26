namespace ResponseWrapperLib.Models.Responses.Identity
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpirationExpiryTime { get; set; }
    }
}
