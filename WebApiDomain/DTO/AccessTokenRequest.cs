using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTO
{
    public class AccessTokenRequest
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }
}
