using DocTerraRestApiLib;
using System;
using System.Linq;

namespace DocTerraRestApiTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DTerra_Connection connection = new DTerra_Connection();
            DTerra_ApiProcedures dTerra_ApiActions = new DTerra_ApiProcedures(connection);
            
            //var pp_info = dTerra_ApiActions.GetProjectsAndPublicationsInfo();

            //bool storage_file_exists = dTerra_ApiActions.IsFileExistsInStorage("project-nbim-sdk/ProductIcon_256.jpg");

            var files_at_project = dTerra_ApiActions.GetFilesInfoFromStorage("project-nbim-sdk", "*", true);
            string oneFileInfo = files_at_project[1].GetFileFullNameWithoutStorage();
            var file_data_at_project = dTerra_ApiActions.GetFileInfoFromStorage(oneFileInfo);
            Console.WriteLine("\nEnd!");
            Console.ReadKey();
        }
    }
}
