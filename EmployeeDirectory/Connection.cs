﻿using System;
using System.Data.SqlClient;

namespace EmployeeDirectory
{
        public class Connection
        {
            public void CONNECTION()
            {

            // put the below into a method...

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost,1433";
            builder.UserID = "sa";
            builder.Password = "<YourStrong@Passw0rd>";
            builder.InitialCatalog = "StaffDirectory";

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

                // James database
                //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                //builder.DataSource = "localhost,1433";
                //builder.UserID = "sa";
                //builder.Password = "Puerr0r@diactiv0";
                //builder.InitialCatalog = "StaffDirectory";



                // connection to the database (local) - SQL server on your laptop...
                // it's not going work to work across... so, when you create your database, copy the code and write it in each time...

                // Jimothy's connection string

                // Emily's connection string

                // Love Island's connection string

                // inserting, selecting, updating and deleting..

                // LOGIC first. Design second. Don't worry or even think about the HTML.
            }
    }
 }
