using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace ServiceRestart
{
    class Program
    {
        // Check to see if the service is installed
        static bool IsServiceInstalled(string myService)
        {
            // Checks for iService name, sets to control variable if it exists
            ServiceController control = ServiceController.GetServices().FirstOrDefault(serv => serv.ServiceName == myService);
            if (control != null)
            { return true; }
            return false;
        }
        static void Main(string[] args)
        {
            // Set service and machine name here
            string myService = "YourServiceNameHere";
            string myMachine = Environment.MachineName.ToString();

            // If myService is installed, attempt to start the service
            if (IsServiceInstalled(myService) == true)
            {
                // Start the service
                Console.WriteLine("Starting \"{0}\"...", myService);
                ServiceController sqlControl = new ServiceController(myService, myMachine);
                sqlControl.Start();
            }
            else
            {
                Console.WriteLine("We attempted to start \"{0}\" however the service could not be found.", myService);
            }

            //wait
            Console.ReadKey();
        }
    }
}
