using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpFinal.Classes
{
    public class Course
    {
        public int Course_ID{ get; set; }
        public string Course_Name{ get; set; }
        public Course()
        {

        }
        public Course(int ci,string cn)
        {
            Course_ID = ci;
            Course_Name = cn;
        }
    }
}