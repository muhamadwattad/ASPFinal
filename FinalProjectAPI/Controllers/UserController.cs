using FinalProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace FinalProjectAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("getlocations")]
        public IHttpActionResult getLocation()
        {
            List<Location> list = SQLdb.GetLocations();
            if (list == null || list.Count == 0)
            {
                return BadRequest("Error");
            }
            return Ok(list);
        }
        [HttpGet]
        [Route("Login/{name}/{password}")]
        public IHttpActionResult Login(string name, string password)
        {
            User u = null;
            u = SQLdb.Login(name, password);
            if (u == null)
                return BadRequest("Failed to login");
            return Ok(u);

        }
        [HttpGet]
        [Route("GetGames/{id}")]
        public IHttpActionResult getGamesByTeamId(int id)
        {
            List<Game> games = SQLdb.GetGames().Where(g => g.awayTeamCode == id || g.homeTeamCode == id).ToList();
            return Ok(games);
        }
        [HttpGet]
        [Route("getGames")]
        public IHttpActionResult getGames()
        {
            List<Game> games = SQLdb.GetGames();
            if (games == null || games.Count == 0)
                return BadRequest("Something went wrong");
            return Ok(games);
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult Test()
        {
            int res = (int)(WebApiApplication.stopWatch.ElapsedMilliseconds / 60000);
            return Ok(res);
        }

        [HttpGet]
        [Route("getgamesbydate/{date}")]
        public IHttpActionResult getgamesbyDate(string date)
        {
            date = date.Replace('-','/');
            List<Game> games = SQLdb.GetGames().Where(game => game.event_date.Contains(date)).ToList();
            if (games == null || games.Count == 0)
                return BadRequest("No Games Found on: " + date);
            return Ok(games);
        }
        [HttpGet]
        [Route("GetTeams")]
        
        public IHttpActionResult GetTeams()
        {
            List<Team> teams = SQLdb.GetTeams();
            if (teams == null||teams.Count!=14)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(teams);
        }

        [HttpGet]
        [Route("getuserteams/{email}")]
        public IHttpActionResult GetFavoriteGameForUser(string email)
        {
            List<Team> teams = SQLdb.getFavoriteTeam(email);
            if (teams == null || teams.Count == 0)
            {
                return BadRequest("NO TEAMS WERE FOUND");
            }
            return Ok(teams);
        }

        [HttpGet]
        [Route("Addteams")]
        ///<summary>
        /// TESTING STUFF MATES
        /// </summary>
     
        public IHttpActionResult addTeams()
        {
            int r=SQLdb.putTeamsAndStadiums();
            return Ok(r);
        }
        [HttpGet]
        [Route("UpdateStatus/{email}/{status}")]
        public IHttpActionResult UpdateStatus(string email, string status)
        {
            int res = SQLdb.UpdateActiveStatus(status, email);
            return Ok(res);
        }
        [HttpGet]
        [Route("AddGames")]
        public IHttpActionResult AddGames()
        {
           int res= SQLdb.putGames();
            return Ok(res);

        }
        [HttpGet]
        [Route("GetGamesBetween2Teams/{team1}/{team2}")]
        public IHttpActionResult getTeamsBetween2Teams(int team1,int team2)
        {
           List<Game> games= SQLdb.GetGames().Where(game => (game.awayTeamCode == team1 && game.homeTeamCode == team2)||(game.homeTeamCode==team1&&game.awayTeamCode==team2)).ToList();
            if(games.Count==0||games==null)
            {
                return BadRequest("no games found");
            }
            return Ok(games);
            
        }


    }
}
