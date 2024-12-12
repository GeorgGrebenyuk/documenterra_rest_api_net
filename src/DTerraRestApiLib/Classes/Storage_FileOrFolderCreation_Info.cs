using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using DocTerraRestApiLib.Enumerations;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание файла или папки для создания или перезаписи в Хранилище
    /// </summary>
    public class Storage_FileOrFolderCreation_Info
    {
        //[JsonIgnore]
        //public FormatVariant format0 { get; set; }
        //public string? format { get { return this.format0.ToString(); } }

        public string? content { get; set; }

        public bool? isFolder { get; set; } = false;

        public Storage_FileOrFolderCreation_Info(string content, bool isFolder = false)
        {
            this.content = content;
            this.isFolder = isFolder;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Storage_FileOrFolderCreation_Info), CommonData.p_JsonSerializerOptions_Write);
        }

    }
}
