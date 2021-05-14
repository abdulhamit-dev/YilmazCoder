using YilmazCoder.Core.Entities;

namespace YilmazCoder.Entities
{
    public class TokenOptions : IEntity
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
