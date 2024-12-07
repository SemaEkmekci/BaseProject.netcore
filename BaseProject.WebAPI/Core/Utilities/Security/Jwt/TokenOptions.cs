namespace BaseProject.WebAPI.Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }

        // Audience: Token'ı kimlerin kullanacağını belirtir.
        // Issuer: Token'ı hangi servisin oluşturduğunu belirtir.
        // AccessTokenExpiration: Token'ın geçerlilik süresini belirtir.
        // SecurityKey: Token'ı imzalamak ve doğrulamak için kullanılan gizli anahtardır.

    }
}
