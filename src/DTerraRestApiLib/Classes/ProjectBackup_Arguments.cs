using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    internal class ProjectBackup_Arguments
    {
        public string? outputFileName { get; set; }

        public ProjectBackup_Arguments(string outputFileName)
        {
            this.outputFileName = outputFileName;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Storage_FilesDelete), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
