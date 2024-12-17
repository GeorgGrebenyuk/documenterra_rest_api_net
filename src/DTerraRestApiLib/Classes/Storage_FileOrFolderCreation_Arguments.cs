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
    public class Storage_FileOrFolderCreation_Arguments
    {
        //[JsonIgnore]
        //public FormatVariant format0 { get; set; }
        //public string? format { get { return this.format0.ToString(); } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? content { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? isFolder { get; set; } = false;

        public Storage_FileOrFolderCreation_Arguments(string? content, bool? isFolder = false)
        {
            this.content = content;
            this.isFolder = isFolder;
        }

        public Storage_FileOrFolderCreation_Arguments(string filePath)
        {
            Byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            content = Convert.ToBase64String(bytes);
            isFolder = false;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Storage_FileOrFolderCreation_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }

    }
}
