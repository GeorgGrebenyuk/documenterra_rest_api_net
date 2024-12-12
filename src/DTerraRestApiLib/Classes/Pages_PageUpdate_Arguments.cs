using System;
using System.Collections.Generic;
using System.Text;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс с информацией о странице, для её обновления
    /// </summary>
    public class Pages_PageUpdate_Arguments
    {
        public string? assigneeUserName { get; set; }

        public string? body { get; set; }

        public string? ownerUserName { get; set; }

        public string? statusName { get; set; }

        public string? title { get; set; }

        public string[]? indexKeywords { get; set; }

        public string? updatedFields { get; internal set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Pages_PageUpdate_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }

    }
}
