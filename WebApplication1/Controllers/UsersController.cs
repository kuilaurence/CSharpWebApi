using System;
using System.Net;
using System.Web.Http;
using MySql.Data.MySqlClient;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class UsersController : ApiController
    {
        //http://localhost:49593/api/Users
        public IEnumerable<Users> GetUsersAll()
        {
            List<Users> listUser = new List<Users>();
            MySqlConnection mySql = GetMySqlConnection();
            MySqlCommand mySqlCommand = GetSqlCommand("select * from student", mySql);
            mySql.Open();
            try
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Users user = new Users();
                        user.ID = reader.GetInt32("id");
                        user.Name = reader.GetString("name");
                        user.Age = reader.GetString("age");
                        listUser.Add(user);
                    }
                }
            }
            catch
            {
                Console.WriteLine(HttpStatusCode.NotFound);
            }
            finally
            {
                mySql.Close();
            }
            return listUser;
        }
        //http://localhost:44349/api/Users/1
        public IEnumerable<Users> GetUsersByID(string id)
        {
            List<Users> listUser = new List<Users>();
            MySqlConnection mySql = GetMySqlConnection();
            MySqlCommand mySqlCommand = GetSqlCommand("select * from student where id = " + id, mySql);
            mySql.Open();
            try
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Users user = new Users();
                        user.ID = reader.GetInt32("id");
                        user.Name = reader.GetString("name");
                        user.Age = reader.GetString("age");
                        listUser.Add(user);
                    }
                }
            }
            catch
            {
                Console.WriteLine(HttpStatusCode.NotFound);
            }
            finally
            {
                mySql.Close();
            }
            return listUser;
        }
        //http://localhost:49593/api/Users?age=21&limit=2&offset=1
        public IEnumerable<Users> GetUsersByAge(string age, string limit, string offset)
        {
            List<Users> listUser = new List<Users>();
            MySqlConnection mySql = GetMySqlConnection();
            MySqlCommand mySqlCommand = GetSqlCommand("select * from student where age = " + age + " limit " + limit + " offset " + offset, mySql);
            mySql.Open();
            try
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Users user = new Users();
                        user.ID = reader.GetInt32("id");
                        user.Name = reader.GetString("name");
                        user.Age = reader.GetString("age");
                        listUser.Add(user);
                    }
                }
            }
            catch
            {
                Console.WriteLine(HttpStatusCode.NotFound);
            }
            finally
            {
                mySql.Close();
            }
            return listUser;
        }
        private static MySqlConnection GetMySqlConnection()
        {
            string host = "localhost";
            string port = "3306";
            string database = "gg";
            string id = "root";
            string pwd = "root";
            string connectionString = string.Format("Server = {0};port={1};Database = {2}; User ID = {3}; Password = {4};", host, port, database, id, pwd);
            MySqlConnection mysql = new MySqlConnection(connectionString);
            return mysql;
        }
        public static MySqlCommand GetSqlCommand(string sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            return mySqlCommand;
        }
    }
}
