using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectAPI.Models
{
    public class Team
    {
        public int team_id { get; set; }
        public string name { get; set; }

        public string logo { get; set; }
        public string country { get; set; }
        public string is_national { get; set; }
        public string venue_name { get; set; }
        public int team_league { get; set; }

        public Team()
        {

        }
        public Team(int team_id, string name,string logo,string country,string is_national,string venue_name,int team_league)
        {
            this.team_id = team_id;
            this.name = name;
            this.logo = logo;
            this.country = country;
            this.is_national = is_national;
            this.venue_name = venue_name;
            this.team_league = team_league;

        }
    }
}