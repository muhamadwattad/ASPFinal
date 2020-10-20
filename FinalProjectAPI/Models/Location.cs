using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectAPI.Models
{
    public class Location
    {
        public int code { get; set; }
        
        public string name { get; set; }
        public Location()
        {
                
        }
        public Location(int c, string n)
        {
            code = c;
            name = n;
           
        }
    }
}