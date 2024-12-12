using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание структуры проекта или публикации (возвращаемое значение из сервера)
    /// </summary>
    public class ProjectOrPublicationInfo
    {
        public string? createdOn { get; set; }

        public string? fullUrl { get; set; }

        public string? id { get; set; }

        public string? parentId { get; set; }

        [Obsolete]
        public string? parentUrl { get; set; }

        public string? title { get; set; }

        [Obsolete]
        public string? url { get; set; }

        public string? visibility { get; set; }

        public static ProjectOrPublicationInfo? LoadFrom(string json)
        {
            return (ProjectOrPublicationInfo?)JsonSerializer.Deserialize(json,
                             typeof(ProjectOrPublicationInfo), CommonData.p_JsonSerializerOptions_Read);
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this, typeof(ProjectOrPublicationInfo), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
