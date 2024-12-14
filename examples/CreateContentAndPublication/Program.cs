using System.IO;
using System;

using DocTerraRestApiLib;

namespace CreateContentAndPublication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectPath = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.FullName ?? "", "dterra_reg.txt");
            DTerra_Connection connection = new DTerra_Connection(projectPath);
            DTerra_ApiProcedures dTerra_ApiActions = new DTerra_ApiProcedures(connection);


        }
    }
}
