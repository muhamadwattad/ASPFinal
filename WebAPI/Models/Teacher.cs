using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Teacher
    {
        public string Password{ get; set; }
        public string Name{ get; set; }
        public Teacher()
        {

        }
        public Teacher(string n,string p)
        {
            Name = n;
            Password = p;
        }
    }

}