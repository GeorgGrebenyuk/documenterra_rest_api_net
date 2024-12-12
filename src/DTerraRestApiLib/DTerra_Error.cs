using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DocTerraRestApiLib
{
    //TODO
    internal class DTerra_Error
    {
        public string Message { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionDetail { get; set; }
        public string StackTrace { get; set; }

        public static DTerra_Error? LoadFrom(string json)
        {
            return (DTerra_Error?)JsonSerializer.Deserialize(json,
                             typeof(DTerra_Error), CommonData.p_JsonSerializerOptions_Read); ;
        }
    }
}
