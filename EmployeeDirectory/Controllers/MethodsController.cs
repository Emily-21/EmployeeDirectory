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

        public ActionResult Select()
        {

            //Emily & Cals databases
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost,1433";
            builder.UserID = "sa";
            builder.Password = "<YourStrong@Passw0rd>";
            // James' password
            //builder.Password = "Puerr0r@diactiv0";
            builder.InitialCatalog = "StaffDirectory";

            // getting all data from StaffModel
            string SELECT = "SELECT * FROM StaffModel";

            Console.WriteLine("Connecting to SQL Server.");

            // establishing a connection to our database
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
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


        //public ActionResult Delete(int IDnum = 4)
        //{


        //    //Emily & Cals databases
        //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        //    builder.DataSource = "localhost,1433";
        //    builder.UserID = "sa";
        //    builder.Password = "<YourStrong@Passw0rd>";
        //    //builder.Password = "Puerr0r@diactiv0";
        //    builder.InitialCatalog = "StaffDirectory";

        //    var employeeDetails = new EmployeeDirectory.Models.EmployeeModel();

        //    string DELETE = $"DELETE FROM StaffModel WHERE EmployeeID = {IDnum}";

        //    Console.WriteLine("Connecting to SQL Server.");

        //    SqlConnection connection = new SqlConnection(builder.ConnectionString);
        //    using (connection)
        //    {
        //        SqlCommand cmd = new SqlCommand(DELETE, connection);
        //        connection.Open();

        //        var model = new List<EmployeeDirectory.Models.EmployeeModel>();

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {

        //                employeeDetails.EmployeeID += (int)reader["EmployeeID"];
        //                employeeDetails.EmployeeName += reader["EmployeeName"].ToString();
        //                employeeDetails.JobTitle += reader["JobTitle"].ToString();
        //                employeeDetails.WorkPlace += reader["WorkPlace"].ToString();
        //                employeeDetails.Email += reader["Email"].ToString();
        //                employeeDetails.PhoneNumber += reader["PhoneNumber"].ToString();

        //                model.Add(employeeDetails);

        //            }
        //        }
        //        return View(model);
        //    }
        //}
    }
}


                  