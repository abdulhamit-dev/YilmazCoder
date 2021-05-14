using System;
using System.Collections.Generic;
using System.Text;

namespace YilmazCoder.Core.Entities.Concrete
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
