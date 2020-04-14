using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class AuthenticationResponseModel
    {
        public string Token { get; set; }
        public string Name { get; set; }
    }
}
