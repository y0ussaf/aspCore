using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public  class User
    {

        public int userId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
 
    }
}
