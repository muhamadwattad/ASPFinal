using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectAPI.Models
{
    public class Game
    {
        public int fixture_id { get; set; }
        public string event_date { get; set; }
        public int event_timestamp { get; set; }
   
        public string round { get; set; }
        public string status{ get; set; }
        public string statusShort{ get; set; }
        public string venue{ get; set; }
        public int homeTeamCode { get; set; }
        public string homeScore { get; set; }
        public string awayScore { get; set; }
        public int awayTeamCode { get; set; }
     
        public Game()
        {

        }

        public Game(int fixture_id, string event_date, int event_timestamp, string round, string status, string statusShort, string venue,int hometeamcode,int awayteamcode,string homeScore,string awayScore)
        {
            this.fixture_id = fixture_id;
            this.event_date = event_date;
            this.event_timestamp = event_timestamp;

            this.round = round;
            this.status = status;
            this.statusShort = statusShort;
            this.venue = venue;
            this.homeTeamCode = hometeamcode;
          
            this.awayTeamCode = awayteamcode;
            this.homeScore = homeScore;
            this.awayScore = awayScore;
        
        }
    }
}