namespace jwtAuthApi.Domain
{
    public class TokenConfiguration
    {
        public string Subject { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationInSeconds { get; set; }
        public string SecretKey { get; set; }
    }
}