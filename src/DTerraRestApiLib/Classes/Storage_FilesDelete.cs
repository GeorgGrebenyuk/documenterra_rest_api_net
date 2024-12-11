using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс для удаления группы файлов из Документерры
    /// </summary>
    public class Storage_FilesDelete
    {
        public string[] fileFullNames {  get; set; }
        public Storage_FilesDelete(string[] fileFullNames)
        {
            this.fileFullNames = fileFullNames;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Storage_FilesDelete), CommonData.p_JsonSerializerOptions_Write);
        }

    }
}
