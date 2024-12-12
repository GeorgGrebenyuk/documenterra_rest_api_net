using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание статуса задачи экспорта публикации
    /// </summary>
    public class PublicationTaskInfo
    {
        public string? taskKey {  get; set; }

        public static PublicationTaskInfo? LoadFrom(string json)
        {
            return (PublicationTaskInfo?)JsonSerializer.Deserialize(json,
                             typeof(PublicationTaskInfo), CommonData.p_JsonSerializerOptions_Read); ;
        }
    }
}
