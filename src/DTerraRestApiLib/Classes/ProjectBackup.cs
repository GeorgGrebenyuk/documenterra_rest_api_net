using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    internal class ProjectBackup
    {
        public string? outputFileName { get; set; }
        public ProjectBackup(string outputFileName)
        {
            this.outputFileName = outputFileName;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Storage_FilesDelete), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
