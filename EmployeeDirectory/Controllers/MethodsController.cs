using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeDirectory.Controllers
{
    public class MethodsController : Controller
    {
        public class EmployeeDetails
        {
            public int EmployeeID;
            public string EmployeeName;
            public string JobTitle;
            public string WorkPlace;
            public string Email;
            public string PhoneNumber;


            public string Select1()
            {
                try
                {

                    //Emily & Cals databases
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "localhost,1433";
                    builder.UserID = "sa";
                    builder.Password = "<YourStrong@Passw0rd>";
                    builder.InitialCatalog = "StaffDirectory";

                    //James database
                    //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    //builder.DataSource = "localhost,1433";
                    //builder.UserID = "sa";
                    //builder.Password = "Puerr0r@diactiv0";
                    //builder.InitialCatalog = "StaffDirectory";

                    string SELECT = "SELECT * FROM StaffModel";

                    Console.WriteLine("Connecting to SQL Server.");

                    SqlConnection connection = new SqlConnection(builder.ConnectionString);
                    using (connection)
                    {
                        SqlCommand cmd = new SqlCommand(SELECT, connection);
                        connection.Open();

                        var model = new List<EmployeeDetails>();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employeeDetails = new EmployeeDetails();
                                employeeDetails.EmployeeID = (int)reader["EmployeeID"];
                                employeeDetails.EmployeeName = (string)reader["EmployeeName"];
                                employeeDetails.JobTitle = (string)reader["JobTitle"];
                                employeeDetails.WorkPlace = (string)reader["WorkPlace"];
                                employeeDetails.Email = (string)reader["Email"];
                                employeeDetails.PhoneNumber = (string)reader["PhoneNumber"];

                                model.Add(employeeDetails);
                            }

                        }
                        return model;
                    }
                }

                catch (SqlException error)
                {
                    return error.ToString();
                }



            }
        }
        public IActionResult Select()
        {
            MethodsController select = new MethodsController();
            ViewData["SelectAll"] = $"{select.Select1()}";
            return View();
        }
    }
}


