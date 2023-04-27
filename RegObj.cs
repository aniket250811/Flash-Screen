using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplashScreenAssignment
{
    internal class RegObj
    {
        string username;
        string email;
        string mobileno;

        string password;

        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Mobileno { get => mobileno; set => mobileno = value; }
    }
}
