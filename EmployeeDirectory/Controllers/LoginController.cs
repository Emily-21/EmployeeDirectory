using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeDirectory.Controllers
{
    public class LoginController : Controller
    {

        //public ActionResult Login(string Email, string Password)
        //{
        //    EmployeeDirectory.Methods.Connection connectionString = new EmployeeDirectory.Methods.Connection();
        //    string newConnection = connectionString.connectionString;


        //    // getting email and password from Stafflogin
        //    string SELECT = $"SELECT '{Email}' AND '{Password}' FROM StaffLogin";

        //    Console.WriteLine("Connecting to SQL Server.");

        //    // establishing a connection to our database
        //    SqlConnection connection = new SqlConnection(newConnection);
        //    using (connection)
        //    {
        //        // taking the command 'SELECT' from database and applying it here 
        //        SqlCommand cmd = new SqlCommand(SELECT, connection);
        //        // opening the connection to allow data to pass
        //        connection.Open();

        //    }


        //    return RedirectToAction("Select");
        //}
    }
}