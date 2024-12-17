using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс с информацией о новой странице, для её создания
    /// </summary>
    public class Pages_PageCreate_Arguments
    {
        public string? assigneeUserName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? body { get; set; }

        public string? id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? isShowInToc { get; set; } = false;

        public string? ownerUserName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? parentTocNodeId { get; set; }

        public string? statusName { get; set; } = "draft";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? tocNodeCaption { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? tocNodeOrdinalNo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? indexKeywords { get; set; }


        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Pages_PageCreate_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
