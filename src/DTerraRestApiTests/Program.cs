using DTerraRestApiLib;
using System;

namespace DTerraRestApiTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DTerra_Connection connection = new DTerra_Connection();
            DTerra_ApiProcedures dTerra_ApiActions = new DTerra_ApiProcedures(connection);
            
            var pp_info = dTerra_ApiActions.GetProjectsAndPublicationsInfo();

            Console.WriteLine("\nEnd!");
            Console.ReadKey();
        }
    }
}
