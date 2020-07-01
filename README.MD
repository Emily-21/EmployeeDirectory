# TalkTalk Project

- Day 1:
- [x] Set up Trello
- [x] Set up database in Azure
- [x] Link database to C#
```
using System;
using System.Data.SqlClient;

namespace EmployeeDirectory
{
   public class Methods
   {

       public void SELECT()
       {
           try
           {

               //Emily & Cals databases
               //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
               //builder.DataSource = "localhost,1433";
               //builder.UserID = "sa";
               //builder.Password = "<YourStrong@Passw0rd>";
               //builder.InitialCatalog = "StaffDirectory";

               //James database
               SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
               builder.DataSource = "localhost,1433";
               builder.UserID = "sa";
               builder.Password = "Puerr0r@diactiv0";
               builder.InitialCatalog = "StaffDirectory";

               //what would you like to send to SQL?
               string SELECT = "SELECT * FROM StaffModel";

               // writing to the console before the connection is attempted
               Console.WriteLine("Connecting to SQL Server.");

               // creating a new instance of the SqlConnection to actually connect to our DB.
               SqlConnection connection = new SqlConnection(builder.ConnectionString);
               using (connection)
               {
                   SqlCommand cmd = new SqlCommand(SELECT, connection);
                   connection.Open();

                   using (SqlDataReader reader = cmd.ExecuteReader())
                   {
                       while (reader.Read())
                       {
                           for (int i = 0; i < reader.FieldCount; i++)
                           {
                               Console.WriteLine(reader.GetValue(i));
                           }
                       }
                   }
                   Console.WriteLine("Done.");
               }
           }

           catch (SqlException error)
           {
               Console.WriteLine(error.ToString());
           }
           Console.WriteLine("No Errors. Done.");
           Console.Read();

       }
```
- [x] Set up GitHub repository
- [x] Create Methods for Adding, Editing and Deleting Employees (To Console)
- [x] Populate the database with dummy data ( employees)

- Day 2:
- [x] Showing all Employee Details (To HTML)
- [x] Display data in a table format

