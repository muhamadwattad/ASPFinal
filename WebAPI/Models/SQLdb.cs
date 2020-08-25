using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SQLdb
    {
        static SqlConnection connection = new SqlConnection("Data Source=muhamad;Initial Catalog=CSharpFinal;Integrated Security=True");
        static SqlCommand command;
        public static int Login(string username, string password)
        {
            command = new SqlCommand("Login", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", username);
            command.Parameters.AddWithValue("@password", password);
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                int res = 0;
                if (reader.Read())
                    res = (int)reader["value"];
                return res;
            }
            catch (Exception e)
            {
                return 0;
            }

            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
        public static List<string> getSubjects()
        {
            List<string> list = new List<string>();
            command = new SqlCommand("SELECT Subject_Name from Subjects", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add((string)reader["Subject_Name"]);
                }
                return list;
            }
            catch (Exception e)
            {
                return list;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
        public static List<Course> GetCourses(int value)
        {
            List<Course> list = new List<Course>();
            command = new SqlCommand("select Course_ID,Course_Name from Courses" +
            $" where Course_Class_ID ={value}", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Course((int)reader["Course_ID"], (string)reader["Course_Name"]));
                }
                connection.Close();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
        public static void CloseCon()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public static int Register(User u, List<string> list)
        {
            command = new SqlCommand("Register", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", u.Email);
            command.Parameters.AddWithValue("@name", u.Name);
            command.Parameters.AddWithValue("@password", u.Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                int res = 0;
                if (reader.Read())
                {
                    res = (int)reader["value"];
                }
                if (res != 1)
                    return 0;
                res = 0;
                connection.Close();
                connection.Open();
                command = new SqlCommand("AddCourses", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", u.Name);
                command.Parameters.AddWithValue("@code1", int.Parse(list[0]));
                command.Parameters.AddWithValue("@code2", int.Parse(list[1]));
                command.Parameters.AddWithValue("@code3", int.Parse(list[2]));
                res = command.ExecuteNonQuery();
                return res;
            }
            catch (Exception e)
            {
                return 0;

            }
            finally
            {
                CloseCon();
            }

        }

        internal static List<string> getByDay(string day)
        {
            List<string> list = new List<string>();
            command = new SqlCommand($"select distinct User_Name as 'Name' from CourseUsers where Day = '{day}'", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    list.Add((string)reader["Name"]);
                }
                connection.Close();
                return list;
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                CloseCon();
            }
            
        }

        public static int SaveDayForCourse(int code, string day, string name)
        {
            command = new SqlCommand("Update CourseUsers" +
                $" SET Day='{day}'" +
                $" Where User_Name='{name}' and Course_ID ='{code}'", connection);
            try
            {
                connection.Open();
                int res = command.ExecuteNonQuery();
                return res;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                CloseCon();
            }
        }

        public static int TeacherLogin(string username, string password)
        {
            command = new SqlCommand("TeacherLogin", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@name", username);
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
                connection.Close();
                return res;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                CloseCon();
            }
        }
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            command = new SqlCommand("select * from Users", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User((string)reader["User_Email"], (string)reader["User_Name"], (string)reader["User_Password"]));
                }
                connection.Close();
                return users;
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                CloseCon();
            }
        }
        public static List<string> GetTeachers()
        {
            command = new SqlCommand("select Teacher_Name from Teachers", connection);
            try
            {
                List<string> list = new List<string>();
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    list.Add((string)reader["Teacher_Name"]);
                }
                connection.Close();
                return list;
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                CloseCon();
            }
        }
        public static int AddTeacher(Teacher t)
        {
            command = new SqlCommand("INSERT INTO Teachers (Teacher_Name,Teacher_Password)" +
                $" VALUES('{t.Name}','{t.Password}')",connection);
            try
            {
                connection.Open();
                int res=command.ExecuteNonQuery();
                connection.Close();
                return res;
            }
            catch(Exception e)
            {
                return 0;
            }
            finally
            {
                CloseCon();
            }
        }
    }
   
}