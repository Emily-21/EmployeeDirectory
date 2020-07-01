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
                string INSERT = "INSERT INTO StaffModel VALUES (5, 'Froddo Baggins', 'Apprentice Digital Developer', 'Soapworks', 'froddo.baggins@talktalkplc.com', '0789373262')";

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
                string UPDATE = "UPDATE StaffModel SET EmployeeName = 'James McGlade Gomez' WHERE EmployeeID = 3";

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


