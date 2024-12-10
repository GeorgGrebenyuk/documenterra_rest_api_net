using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using DTerraRestApiLib.ProjectAndPublication;

namespace DTerraRestApiLib
{

    public class DTerra_ApiProcedures
    {
        private DTerra_Connection p_Connection;

        public DTerra_ApiProcedures(DTerra_Connection p_Connection)
        {
            this.p_Connection = p_Connection;
        }

        public ProjectOrPublication_Info? GetProjectOrPublicationInfo(string id)
        {
            string json = "";
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{id}", "", out json);

            return ProjectOrPublication_Info.LoadFrom(json);
        }

        public ProjectOrPublication_Info[]? GetProjectsAndPublicationsInfo()
        {
            string json = "";
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects", "", out json);

            return (ProjectOrPublication_Info[]?)JsonSerializer.Deserialize(json,
                             typeof(ProjectOrPublication_Info[]), CommonData.p_JsonSerializerOptions_Read);

        }
    }
}
