using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAngular
{
    public class LocalMailService
    {

        private string _mailTo = Startup.Configuration["test"];
        private string _mailFrom = "admin2@m.com";

        public void Send (string subject, string message)
        {
            Console.WriteLine($"{message} sent with {subject}");
        }
    }
}
