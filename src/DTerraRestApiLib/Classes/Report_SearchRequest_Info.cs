using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание поискового запроса пользователя
    /// </summary>
    public class Report_SearchRequest_Info
    {
        public DateTime? dateTime { get; set; }

        public string? queryText { get; set; }

        public int? resultsTotal { get; set; }

        public string? projectId { get; set; }

        public static Report_SearchRequest_Info? LoadFrom(string json)
        {
            return (Report_SearchRequest_Info?)JsonSerializer.Deserialize(json,
                             typeof(Report_SearchRequest_Info), CommonData.p_JsonSerializerOptions_Read);
        }
    }
}
