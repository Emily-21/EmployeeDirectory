using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeDirectory.Controllers
{
 

    public class MethodsController : Controller
    {

        public IActionResult Insert()
        {
            return View();
        }


        public IActionResult Update()
        {
            return View();
        }


        public ActionResult Login(string Email, string Password)
        {
            EmployeeDirectory.Methods.Connection connectionString = new EmployeeDirectory.Methods.Connection();
            string newConnection = connectionString.connectionString;


            // getting email and password from Stafflogin
            string SELECT = $"SELECT * FROM StaffLogin WHERE Email = '{Email}' AND Password = '{Password}' ";

            Console.WriteLine("Connecting to SQL Server.");

            // establishing a connection to our database
            SqlConnection connection = new SqlConnection(newConnection);
            using (connection)
            {
                // taking the command 'SELECT' from database and applying it here 
                SqlCommand cmd = new SqlCommand(SELECT, connection);
                // opening the connection to allow data to pass
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var employeeLogin = new EmployeeDirectory.Models.EmployeeLogin();
                        // where is this coming from? Models Folder/EmployeeModel Class
                        // creating a new variable, 'employeeDetails', that passes values for the list.

                        employeeLogin.Email = reader["Email"].ToString();
                        employeeLogin.Password = reader["Password"].ToString();

                        // model = list and adds employeeDetails to a list format
                        //model.Add(employeeLogin);

                        
                        if (employeeLogin == null)
                        {
                            ViewBag.error = "Error";
                        }
                        else
                        {
                            return RedirectToAction("Select");
                        }
               

                    }
                    return View();

                }


            }
        }





        public ActionResult Select()
        {
            EmployeeDirectory.Methods.Connection connectionString = new EmployeeDirectory.Methods.Connection();
            string newConnection = connectionString.connectionString;
            

            // getting all data from StaffModel
            string SELECT = "SELECT * FROM StaffModel";

            Console.WriteLine("Connecting to SQL Server.");

            // establishing a connection to our database
            SqlConnection connection = new SqlConnection(newConnection);
            using (connection)
            {
                // taking the command 'SELECT' from database and applying it here 
                SqlCommand cmd = new SqlCommand(SELECT, connection);
                // opening the connection to allow data to pass
                connection.Open();

                // creating a new variable, 'model', turning it into a list.
                var model = new List<EmployeeDirectory.Models.EmployeeModel>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var employeeDetails = new EmployeeDirectory.Models.EmployeeModel();
                        // where is this coming from? Models Folder/EmployeeModel Class
                        // creating a new variable, 'employeeDetails', that passes values for the list.
                        employeeDetails.EmployeeID = (int)reader["EmployeeID"];
                        employeeDetails.EmployeeName = reader["EmployeeName"].ToString();
                        employeeDetails.JobTitle = reader["JobTitle"].ToString();
                        employeeDetails.WorkPlace = reader["WorkPlace"].ToString();
                        employeeDetails.Email = reader["Email"].ToString();
                        employeeDetails.PhoneNumber = reader["PhoneNumber"].ToString();

                        // model = list and adds employeeDetails to a list format
                        model.Add(employeeDetails);

                    }
                }
                connection.Close();
                // returns the model (which now has data)
                return View(model);
            }
        }

        public ActionResult Search(int EmployeeID)
        {
           
            EmployeeDirectory.Methods.Connection connectionString = new EmployeeDirectory.Methods.Connection();
            string newConnection = connectionString.connectionString;
            var employeeDetails = new EmployeeDirectory.Models.EmployeeModel();
            string SEARCH = $"SELECT * FROM StaffModel WHERE EmployeeID={EmployeeID}";

            SqlConnection connection = new SqlConnection(newConnection);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(SEARCH, connection);
                connection.Open();
                var model = new List<EmployeeDirectory.Models.EmployeeModel>();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employeeDetails.EmployeeID += (int)reader["EmployeeID"];
                        employeeDetails.EmployeeName += reader["EmployeeName"].ToString();
                        employeeDetails.JobTitle += reader["JobTitle"].ToString();
                        employeeDetails.WorkPlace += reader["WorkPlace"].ToString();
                        employeeDetails.Email += reader["Email"].ToString();
                        employeeDetails.PhoneNumber += reader["PhoneNumber"].ToString();
                        //Console.WriteLine(employeeDetails);
                        model.Add(employeeDetails);
                    }
                    connection.Close();
                    return View(model);
                }
            }
        }


        public ActionResult Delete(int EmployeeID)
            // EmployeeID is the variable that allows us to change that Value
        {

            EmployeeDirectory.Methods.Connection connectionString = new EmployeeDirectory.Methods.Connection();
            string newConnection = connectionString.connectionString;
    

            var employeeDetails = new EmployeeDirectory.Models.EmployeeModel();

            string DELETE = $"DELETE FROM StaffModel WHERE EmployeeID={EmployeeID}";
            // calling the DELETE method from StaffModel
            // EmployeeID QUOTATION = DATABASE
            // EmployeeID PARAMETER = VALUE

            Console.WriteLine("Connecting to SQL Server.");

            SqlConnection connection = new SqlConnection(newConnection);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(DELETE, connection);
                connection.Open();

                var model = new List<EmployeeDirectory.Models.EmployeeModel>();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        employeeDetails.EmployeeID += (int)reader["EmployeeID"];
                        employeeDetails.EmployeeName += reader["EmployeeName"].ToString();
                        employeeDetails.JobTitle += reader["JobTitle"].ToString();
                        employeeDetails.WorkPlace += reader["WorkPlace"].ToString();
                        employeeDetails.Email += reader["Email"].ToString();
                        employeeDetails.PhoneNumber += reader["PhoneNumber"].ToString();

                        model.Remove(employeeDetails);
                    }
                    return RedirectToAction("Select");
                }
            }
        }


        [HttpPost]
        public ActionResult Insert(int EmployeeID, string EmployeeName, string JobTitle, string WorkPlace, string Email, string PhoneNumber)
        {

            EmployeeDirectory.Methods.Connection connectionString = new EmployeeDirectory.Methods.Connection();
            string newConnection = connectionString.connectionString;
           

       

            string INSERT = $"INSERT INTO StaffModel VALUES ({EmployeeID}, '{EmployeeName}', '{JobTitle}', '{WorkPlace}', '{Email}', '{PhoneNumber}')";


            Console.WriteLine("Connecting to SQL Server.");

            SqlConnection connection = new SqlConnection(newConnection);
           
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(INSERT, connection);
                connection.Open();

            

                cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);
                cmd.Parameters.AddWithValue("EmployeeName", EmployeeName);
                cmd.Parameters.AddWithValue("JobTitle", JobTitle);
                cmd.Parameters.AddWithValue("WorkPlace", WorkPlace);
                cmd.Parameters.AddWithValue("Email", Email);
                cmd.Parameters.AddWithValue("PhoneNumber", PhoneNumber);

                cmd.ExecuteNonQuery();

                return RedirectToAction("Select");
            }
        }

        [HttpPost]
        public ActionResult Update(int EmployeeID, string EmployeeName, string JobTitle, string WorkPlace, string Email, string PhoneNumber)
        {
            {
            EmployeeDirectory.Methods.Connection connectionString = new EmployeeDirectory.Methods.Connection();
            string newConnection = connectionString.connectionString;

            string UPDATE = $"UPDATE StaffModel SET EmployeeName = '{EmployeeName}', JobTitle = '{JobTitle}', WorkPlace = '{WorkPlace}', Email = '{Email}', PhoneNumber = '{PhoneNumber}' WHERE EmployeeID = {EmployeeID}";


            SqlConnection connection = new SqlConnection(newConnection);

            using (connection)

                {
                    SqlCommand cmd = new SqlCommand(UPDATE, connection);
                    connection.Open();



                    cmd.Parameters.AddWithValue("EmployeeID", EmployeeID);
                    cmd.Parameters.AddWithValue("EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("JobTitle", JobTitle);
                    cmd.Parameters.AddWithValue("WorkPlace", WorkPlace);
                    cmd.Parameters.AddWithValue("Email", Email);
                    cmd.Parameters.AddWithValue("PhoneNumber", PhoneNumber);

                    cmd.ExecuteNonQuery();

                    return RedirectToAction("Select");
                }
              
            }
        }
    }
}
