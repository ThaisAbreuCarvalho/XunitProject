using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class AccessTokenResponse
    {
        public string Token { get; set; }
        public string ExpirationTime { get; set; }
        public string Type { get; set; }
    }
}
