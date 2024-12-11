using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Информация об одном файле в хранилище
    /// </summary>
    public class Storage_FileInfo
    {
        public string fileName {  get; set; }

        public string fileFullName { get; set; }

        /// <summary>
        /// Конвертация fileFullName в путь для Documenterra (смена слэшей и удаление начала пути со Storage)
        /// </summary>
        /// <returns></returns>
        public string GetFileFullNameWithoutStorage()
        {
            return fileFullName.Replace("\\", "/").Replace("Storage/", "");
        }

        public string content { get; set; }

        public string modifiedBy { get; set; }

        public string modifiedOn { get; set; }

        public int size { get; set; }

        public bool isFolder { get; set; }

        public static Storage_FileInfo? LoadFrom(string json)
        {
            return (Storage_FileInfo?)JsonSerializer.Deserialize(json,
                             typeof(Storage_FileInfo), CommonData.p_JsonSerializerOptions_Read); ;
        }
    }
}
