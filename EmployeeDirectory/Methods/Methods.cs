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
                string INSERT = "INSERT INTO StaffModel VALUES (4, 'Saul Goodman', 'Legal Department', 'Soapworks', 'better.callsaul@talktalkplc.com', '0765400998'), (5, 'Brian Kempt', 'Digital Line Manager', 'Soapworks', 'brian.kempt@talktalkplc.com', '0765436478'), (6, 'Nelson Van Alden', 'Finances', 'Edinburgh', 'nelson.vanalden@talktalkplc.com', '0765400322'), (7, 'John Goode', 'Customer Service', 'Soapworks', 'johnnyb.goode@talktalkplc.com', '0765430572')";



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
                string DELETE = "DELETE FROM StaffModel WHERE EmployeeID = 11";

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


