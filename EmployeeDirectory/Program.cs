using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeDirectory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            Methods select = new Methods();
            select.SELECT();

            Methods insert = new Methods();
            //insert.INSERT();

            Methods update = new Methods();
            //update.UPDATE();

            Methods delete = new Methods();
            //delete.DELETE();
        }

        //    public static IHostBuilder CreateHostBuilder(string[] args) =>
        //        Host.CreateDefaultBuilder(args)
        //            .ConfigureWebHostDefaults(webBuilder =>
        //            {
        //                webBuilder.UseStartup<Startup>();
        //            });
        //}
    }
}

// James is the best not Jacob. This is a lie.
// my name is Callum and this is correct. James is not as good as Jacob.
