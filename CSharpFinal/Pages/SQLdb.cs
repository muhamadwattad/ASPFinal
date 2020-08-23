using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CSharpFinal.Pages
{

    public class SQLdb
    {
        static SqlConnection connection = new SqlConnection("Data Source=muhamad;Initial Catalog=CSharpFinal;Integrated Security=True");
        static SqlCommand command;

        public static int Login(string username,string password)
        {
            command = new SqlCommand("Login",connection);
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
            catch(Exception e)
            {
                return 0;
            }

            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}