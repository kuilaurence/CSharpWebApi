using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        public IEnumerable<Users> GetUsersAll()
        {
            List<Users> listUser = new List<Users>();
            MySqlConnection mySql = GetMySqlConnection();
            MySqlCommand mySqlCommand = GetSqlCommand("select * from student", mySql);
            mySql.Open();
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
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
                throw new HttpResponseException(HttpStatusCode.NotFound);
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
            string database = "mysql";
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
