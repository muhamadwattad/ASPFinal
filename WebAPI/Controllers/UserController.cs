using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("Getallusers")]
        public IHttpActionResult getAllUsers()
        {
            List<User> users = new List<User>();
            users = SQLdb.GetUsers();
            if (users == null || users.Count == 0)
            {
                return BadRequest("Could not get users or theres no users.");
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("Getuserbyname/{name}")]
        public IHttpActionResult getUserByName(string name)
        {
            User u = null;
            u = SQLdb.GetUsers().SingleOrDefault(st => st.Name == name);
            if (u == null)
            {
                return BadRequest($"User With Name {name} Was not found");
            }
            return Ok(u);
        }
        [HttpGet]
        [Route("login/{username}/{password}")]
        public IHttpActionResult Login(string username, string password)
        {
            int res = 0;
            res = SQLdb.Login(username, password);
            if (res == 1)
            {
                return Ok("Logged in Succesfully!");
            }
            return BadRequest("Failed to login");
        }
        [HttpPost]
        [Route("Register")]
        //http://localhost:50708/Register?list=1&list=3&list=4 
        public IHttpActionResult Register([FromBody]User u, [FromUri]List<string> list)
        {
            if (list.Count != 3)
            {
                return BadRequest("Size of list must be 3.");
            }
            int res = 0;
            res = SQLdb.Register(u, list);
            if (res == 3)
            {
                return Ok("Signed up succesfully!");
            }
            else
            {
                return BadRequest("Could not Signup");
            }
        }

        [HttpGet]
        [Route("GetSubjects")]
        public IHttpActionResult GetSubjects()
        {
            List<string> list = new List<string>();
            list = SQLdb.getSubjects();
            if (list == null || list.Count == 0)
            {
                return BadRequest("Something went wrong...");
            }
            return Ok(list);
        }

        [HttpGet]
        [Route("GetCoursesBySubjectCode/{value}")]
        public IHttpActionResult getCourses(int value)
        {
            List<Course> list = new List<Course>();
            list = SQLdb.GetCourses(value);
            if (list == null || list.Count == 0)
            {
                return BadRequest("This Code Does not exist.");
            }
            return Ok(list);

        }
        [HttpGet]
        [Route("GetTeachers")]
        public IHttpActionResult GetTeachers()
        {
            List<string> list = SQLdb.GetTeachers();
            if (list == null || list.Count == 0)
            {
                return BadRequest("Could not get teachers.");
            }
            return Ok(list);
        }
        [HttpGet]
        [Route("GetTeacherByName/{name}", Name = "GetTeacherByName")]
        public IHttpActionResult GetTeacherByName(string name)
        {
            string x = null;
            x = SQLdb.GetTeachers().SingleOrDefault(st => st.ToLower() == name.ToLower());
            if (x == null)
            {
                return BadRequest($"The Teacher with Name {name} Does not exist");
            }
            return Ok("This Teacher Exists");
        }
        [HttpPut]
        [Route("AddTeacher")]
        public IHttpActionResult AddTeacher([FromBody]Teacher teacher)
        {
            int res = SQLdb.AddTeacher(teacher);
            if (res == 0)
            {
                return BadRequest("Could not Add the teacher.");
            }
            else
            {
                return Ok("User has been created!");
            }
        }

        [HttpGet]
        [Route("GetByDay/{day}")]
        public IHttpActionResult WhoStudyonThisDay(string day)
        {

            string[] arr = new string[] { "Sunday", "Monday", "Theusday", "Wendsday", "Thursday", "Friday" };
            string x = arr.SingleOrDefault(st => st.ToLower() == day.ToLower());
            if (x == null)
            {
                return BadRequest("Please Choose a day.");
            }
            List<string> list = new List<string>();
            list=SQLdb.getByDay(day);
            if(list==null||list.Count==0)
            {
                return BadRequest("No one Studies on that day.");
            }
            return Ok(list);
        }
        

    }

}
