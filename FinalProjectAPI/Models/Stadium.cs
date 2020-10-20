using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectAPI.Models
{
    public class Stadium 
    {
        public string venue_name { get; set; }
        public string venue_surface { get; set; }
        public string venue_adress { get; set; }
        public string venue_city { get; set; }
        public int venue_capacity { get; set; }

        public Stadium(string venue_name, string venue_surface, string venue_adress, string venue_city, int venue_capacity)
        {
            this.venue_name = venue_name;
            this.venue_surface = venue_surface;
            this.venue_adress = venue_adress;
            this.venue_city = venue_city;
            this.venue_capacity = venue_capacity;
        }

        public Stadium()
        {

        }

        
    }
}