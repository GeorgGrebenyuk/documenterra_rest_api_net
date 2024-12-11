using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс для обновления файла в хранилище
    /// </summary>
    public class Storage_FileUpdateInfo
    {
        public string updatedFields { get; set; }

        public string content { get; set; }

        public Storage_FileUpdateInfo(string content)
        {
            this.updatedFields = "content";
            this.content = content;
        }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Storage_FileUpdateInfo), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
