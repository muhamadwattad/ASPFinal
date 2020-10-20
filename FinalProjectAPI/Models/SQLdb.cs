using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using HtmlAgilityPack;
using System.Net;
using unirest_net.http;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Data;
using MoreLinq.Extensions;

namespace FinalProjectAPI.Models
{
    public class SQLdb
    {

        static string connectionString = @"Data Source=sql6010.site4now.net;Initial Catalog=DB_A4B73A_wattad;User ID=DB_A4B73A_wattad_admin;Password=!@wattad951753@!";
        static SqlConnection connection = new SqlConnection(connectionString);
        static SqlCommand command;

        public static List<Location> GetLocations()
        {
            List<Location> list = new List<Location>();
            //GETTING LOCATION CODE AND NAME FROM DATABASE!
            string comTxt = "SELECT Location_Code as code, Location_Name as name from Location";
            command = new SqlCommand(comTxt, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Location((int)reader["code"], (string)reader["name"]));
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                TurnConn();
            }
        }

        public static List<User> GetUsers()
        {
            //GET USERS AND SAVE THEM INTO LIST
            List<User> list = new List<User>();
            string cmdTxt = "GetUsers";
            command = new SqlCommand(cmdTxt, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new User((string)reader["user_Email"], (string)reader["user_Password"], (string)reader["user_Name"], (string)reader["user_Image"], (string)reader["Location_Name"],(string)reader["User_Active"]));
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                TurnConn();
            }
        }
        public static User Login(string name, string password)
        {
            string cmdTxt = "Login";
            command = new SqlCommand(cmdTxt, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@password", password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int res = 0;
                if (reader.Read())
                {
                    res = (int)reader["value"];
                }
                if (res == 0)
                    return null;
                TurnConn();
                return GetUsers().SingleOrDefault(st => st.name.ToLower() == name.ToLower() && st.password == password);
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                TurnConn();
            }
        }

        private static void TurnConn()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public static int putTeamsAndStadiums()
        {
            var url = "https://api-football-v1.p.rapidapi.com/v2/teams/league/2708?";
            //Getting teams from API
            HttpResponse<string> response = Unirest.get(url)
               .header("x-rapidapi-host", "api-football-v1.p.rapidapi.com")
               .header("x-rapidapi-key", "f9b1f6184amshd2535cf90bae600p1c7edfjsn7567501c9a89")
               .header("Accept", "application/json")
               .asJson<string>();
            //turning the result to string
            string r = response.Body.ToString();

            List<Team> teams = null;
            List<Stadium> stadiums = null;
            try
            {
                //Getting The results as JSON
                JObject json = JObject.Parse(r);
                //Getting the reuslts as objects
                JToken jApi = json["api"]["teams"];

                teams = new List<Team>();
                stadiums = new List<Stadium>();
                //adding teams and stadiums to lists
                foreach (var i in jApi)
                {
                    teams.Add(new Team((int)i["team_id"], (string)i["name"], (string)i["logo"], (string)i["country"], (string)i["is_national"], (string)i["venue_name"]));

                    stadiums.Add(new Stadium((string)i["venue_name"], (string)i["venue_surface"], (string)i["venue_adress"], (string)i["venue_city"], (int)i["venue_capacity"]));

                }

            }
            catch (Exception e) { return 0; }
            //Checking Conditions
            if (teams == null || teams.Count != 14 || stadiums.Count == 0 || stadiums == null)
            {
                return 0;
            }
            //Remove duplicated stadiums
            List<Stadium> newStadiums = stadiums.DistinctBy(st => st.venue_name).ToList();

            //Removing Current Stadiumds And Teams And Games
            RemoveTeamsAndStadiumsAndGames();

            //adding stadiums to database
            try
            {

                foreach (Stadium i in newStadiums)
                {

                    command = new SqlCommand("AddStadiums", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Venue_name", i.venue_name ?? "not found");
                    command.Parameters.AddWithValue("@Venue_surface", i.venue_surface ?? "not found");
                    command.Parameters.AddWithValue("@Venue_adress", i.venue_adress ?? "not found");
                    command.Parameters.AddWithValue("@Venue_city", i.venue_city ?? "not found");
                    command.Parameters.AddWithValue("@Venue_capacity", i.venue_capacity);
                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    if (res == 0)
                        return 0;
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                TurnConn();
            }

            //Adding Teams to Database
            try
            {
                foreach (Team i in teams)
                {
                    command = new SqlCommand("AddToTeams", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Team_ID", i.team_id);
                    command.Parameters.AddWithValue("@Team_name", i.name);
                    command.Parameters.AddWithValue("@Team_logo", i.logo);
                    command.Parameters.AddWithValue("@Team_country", i.country);
                    command.Parameters.AddWithValue("@Team_is_national", i.is_national);
                    command.Parameters.AddWithValue("@Team_venue_name", i.venue_name);

                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    if (res == 0)
                        return 0;
                    connection.Close();
                }
            }
            catch (Exception e) { return 0; }
            finally
            {
                TurnConn();
            }

            return 1;




        }

        public static int putGames()
        {
            var url = "https://api-football-v1.p.rapidapi.com/v2/fixtures/league/2708?timezone=asia/jerusalem";
            HttpResponse<string> response;

            try
            {
                //GETTING DATA FROM API
                response = Unirest.get(url)
                              .header("x-rapidapi-host", "api-football-v1.p.rapidapi.com")
                              .header("x-rapidapi-key", "f9b1f6184amshd2535cf90bae600p1c7edfjsn7567501c9a89")
                              .header("Accept", "application/json")
                              .asJson<string>();
                if (response.Code != 200)
                    return 0;
            }
            catch (Exception e)
            {
                return 0;
            }

            List<Game> games = null;
            string r = response.Body.ToString();
            if (r == null||r.Length==0)
                return 0;
            try
            {

                JObject json = JObject.Parse(r);
                JToken jApi = json["api"]["fixtures"];
                games = new List<Game>();
                foreach (var i in jApi)
                {
                    JToken home = i["homeTeam"];
                    JToken away = i["awayTeam"];
                    games.Add(new Game((int)i["fixture_id"], (string)i["event_date"], (int)i["event_timestamp"], (string)i["round"], (string)i["status"], (string)i["statusShort"], (string)i["venue"], (int)home["team_id"], (int)away["team_id"],(string)i["goalsHomeTeam"]??"-",(string)i["goalsAwayTeam"]??"-"));

                }


            }
            catch (Exception e) { return 0; }

            try
            {
                //Removing outdated games to replace them with updated ones
                TurnConn();
                command = new SqlCommand("delete from Games", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                //Adding games to the Database
                foreach (Game i in games)
                {
                    command = new SqlCommand("AddGames", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Fixture_id", i.fixture_id);
                    command.Parameters.AddWithValue("@Fixture_date", i.event_date);
                    command.Parameters.AddWithValue("@Fixture_timestamp", i.event_timestamp);
                    command.Parameters.AddWithValue("@Fixture_round", i.round);
                    command.Parameters.AddWithValue("@Fixture_status", i.status);
                    command.Parameters.AddWithValue("@Fixture_statusShort", i.statusShort);
                    command.Parameters.AddWithValue("@Fixture_venue", i.venue);
                    command.Parameters.AddWithValue("@Fixture_homeTeamcode", i.homeTeamCode);
                    command.Parameters.AddWithValue("@Fixture_awayTeamcode", i.awayTeamCode);
                    command.Parameters.AddWithValue("@homeScore", i.homeScore);
                    command.Parameters.AddWithValue("@awayScore", i.awayScore);
                    connection.Open();
                    int res = command.ExecuteNonQuery();
                    if (res == 0)
                        return 0;
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                TurnConn();
                command = new SqlCommand("delete from Games", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                return 0;
            }
            finally
            {
                TurnConn();
            }
            return 1;
        }

        public static List<Game> GetGames()
        {
            List<Game> games = new List<Game>();
            try
            {
                command = new SqlCommand("getGames", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader i = command.ExecuteReader();
                while (i.Read())
                {
                    games.Add(new Game((int)i["Fixture_id"], (string)i["Fixture_date"], (int)i["Fixture_timestamp"], (string)i["Fixture_round"], (string)i["Fixture_status"], (string)i["Fixture_statusShort"], (string)i["Fixture_venue"], (int)i["Fixture_homeTeamcode"], (int)i["Fixture_awayTeamcode"],(string)i["homeScore"],(string)i["awayScore"]));
                }
            }
            catch (Exception e) { return null; }
            finally
            {
                TurnConn();
            }
            return games;
        }
        public static List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>();
            command = new SqlCommand("getTeams", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                connection.Open();
                SqlDataReader i = command.ExecuteReader();
                while (i.Read())
                {
                    teams.Add(new Team((int)i["Team_ID"], (string)i["Team_name"], (string)i["Team_logo"], (string)i["Team_country"], (string)i["Team_is_national"], (string)i["Team_venue_name"]));
                }
                connection.Close();
                return teams;
            }
            catch(Exception e) { return null; }
            finally
            {
                TurnConn();
            }
            
        }

        public static void RemoveTeamsAndStadiumsAndGames()
        {
            //REMOVING GAMES/Stadiums/TEAMS FROM DATABASE
            command = new SqlCommand("delete from Teams", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command = new SqlCommand("delete from Stadiums", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command = new SqlCommand("delete from Games", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static List<Team> getFavoriteTeam(string email)
        {
            command = new SqlCommand("GetFavoriteTeam", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", email);
            List<Team> teams = new List<Team>();
            try
            {

                connection.Open();
                SqlDataReader i=command.ExecuteReader();
                while (i.Read())
                {
                    teams.Add(new Team((int)i["Team_ID"], (string)i["Team_name"],(string)i["Team_logo"],(string)i["Team_country"],(string)i["Team_is_national"],(string)i["Team_venue_name"]));
                }
                return teams;
            }
            catch(Exception e) { return null; }
            finally
            {
                TurnConn();
            }
        }
        public static int UpdateActiveStatus(string status,string email)
        {
            command = new SqlCommand("UpdateActiveStatus", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@status", status);
            try
            {
                connection.Open();
                int res=command.ExecuteNonQuery();
                return res;
            }
            catch(Exception e) { return 0; }
            finally
            {
                TurnConn();
            }
        }

    }
}