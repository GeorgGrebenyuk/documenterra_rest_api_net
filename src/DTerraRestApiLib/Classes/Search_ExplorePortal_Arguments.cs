using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс для задания входных данных параметров поискового запроса по порталу
    /// </summary>
    public class Search_ExplorePortal_Arguments
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int count { get; set; } = 10;

        [Obsolete]
        [JsonIgnore]
        private string? projectUrls { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? projectIds { get { return string.Join(",", projectIds0 ?? new string[] { }); } }

        [JsonIgnore]
        public string[] projectIds0 { get; set; } = new string[] { };

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? lang { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? isReturnSnippets { get; set; }

        public string q { get; set; }
    }
}
