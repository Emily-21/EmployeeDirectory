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
                            for (int i = 0; i<reader.FieldCount; i++)
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

        public void INSERT()
        {
            try
            {
                // Emily & Cals databases
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost,1433";
                builder.UserID = "sa";
                builder.Password = "<YourStrong@Passw0rd>";
                builder.InitialCatalog = "StaffDirectory";

                //what would you like to send to SQL?
                string INSERT = "INSERT INTO StaffModel VALUES (10, 'Stuart Silverman', 'HR Director', 'Soapworks', 'stuart.silverman@talktalkplc.com', '0765432119'), (11, 'Roy Hawkins', 'HelpDesk', 'London', 'roy.hawkins@talktalkplc.com', '0765432119')";



                // writing to the console before the connection is attempted
                Console.WriteLine("Connecting to SQL Server.");

                // creating a new instance of the SqlConnection to actually connect to our DB.
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(INSERT, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();

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

        public void UPDATE()
        {
            try
            {
                // Emily & Cals databases
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "localhost,1433";
                builder.UserID = "sa";
                builder.Password = "<YourStrong@Passw0rd>";
                builder.InitialCatalog = "StaffDirectory";

                //what would you like to send to SQL?
                string UPDATE = "UPDATE StaffModel SET PhoneNumber = '0754321545' WHERE EmployeeID = 6";

        // writing to the console before the connection is attempted
        Console.WriteLine("Connecting to SQL Server.");

                // creating a new instance of the SqlConnection to actually connect to our DB.
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(UPDATE, connection);
    connection.Open();
                    cmd.ExecuteNonQuery();

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

        public void DELETE()
        {
            try
            {
                // Emily & Cals databases
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "localhost,1433";
                builder.UserID = "sa";
                builder.Password = "<YourStrong@Passw0rd>";
                builder.InitialCatalog = "StaffDirectory";

                //what would you like to send to SQL?
                string DELETE = "DELETE FROM StaffModel WHERE MovieID = 4";

                // writing to the console before the connection is attempted
                Console.WriteLine("Connecting to SQL Server.");

                // creating a new instance of the SqlConnection to actually connect to our DB.
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(DELETE, connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();

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
    }
}


