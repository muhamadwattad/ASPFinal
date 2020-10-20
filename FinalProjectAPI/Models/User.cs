using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectAPI.Models
{
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public string location { get; set; }
        public string active { get; set; }
        public User()
        {

        }
        public User(string em,string pa,string na,string im,string loc,string active)
        {
            name = na;
            password = pa;
            email = em;
            image = im;
            location = loc;
            this.active = active;
        }
    }
}