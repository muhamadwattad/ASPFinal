using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpFinal.Classes
{
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public User()
        {

        }
        public User(string e,string n,string p)
        {
            Email = e;
            Name = n;
            Password = p;
        }
    }
}