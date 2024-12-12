using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using DocTerraRestApiLib.Enumerations;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Описание истории посещения пользователями страницы
    /// </summary>
    public class Report_PageVisit_info
    {
        public string? actionType { private get; set; }

        [JsonIgnore]
        public actionTypeVariant actionType0 { get { return (actionTypeVariant)Enum.Parse(typeof(actionTypeVariant), actionType ?? "_None", true); } }

        public DateTime? dateTime { get; set; }

        public string? href { get; set; }
        public string? referrerUrl { get; set; }

        public static Report_PageVisit_info? LoadFrom(string json)
        {
            return (Report_PageVisit_info?)JsonSerializer.Deserialize(json,
                             typeof(Report_PageVisit_info), CommonData.p_JsonSerializerOptions_Read);
        }
    }
}
