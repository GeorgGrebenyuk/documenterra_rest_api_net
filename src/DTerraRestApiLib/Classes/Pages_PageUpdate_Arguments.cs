using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс с информацией о странице, для её обновления
    /// </summary>
    public class Pages_PageUpdate_Arguments
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? assigneeUserName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? body { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ownerUserName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? statusName { get; set; } = "draft";

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string[]? indexKeywords { get; set; }

        public string? updatedFields { get; set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Pages_PageUpdate_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }

    }
}
