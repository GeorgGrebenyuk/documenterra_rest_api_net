using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание статуса публикации
    /// </summary>
    public class PublicationTaskStatusInfo
    {
        public bool? isSucceeded { get; set; }

        public bool? isWorking { get; set; }

        public int? maxOverallProgress { get; set; }

        public int? overallProgress { get; set; }

        public string? statusText { get; set; }

        public string? taskName { get; set; }

        public static PublicationTaskStatusInfo? LoadFrom(string json)
        {
            return (PublicationTaskStatusInfo?)JsonSerializer.Deserialize(json,
                             typeof(ProjectOrPublicationInfo), CommonData.p_JsonSerializerOptions_Read);
        }


    }
}
