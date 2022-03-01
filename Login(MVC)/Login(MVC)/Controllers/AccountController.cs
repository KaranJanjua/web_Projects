using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_MVC_.Models;
using System.Data.SqlClient;

namespace Login_MVC_.Controllers
{
    public class AccountController : Controller
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = "Data Source= KARANBIRJANFBF6\\SQLSERVER ;Initial Catalog=Test;Integrated Security=SSPI;";
        }
        [HttpPost]
        public ActionResult Verify(Account acc) 
        {
            ConnectionString();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from [Test].[dbo].[tbl_login] where name= '"+acc.Name+"' and Password = '"+acc.Password+"';";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Logged_In");
            }
            else 
            {
                con.Close();
                return View("Error"); 
            }
        }
    }
}