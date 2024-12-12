using System;
using System.Collections.Generic;
using System.Text;

namespace DocTerraRestApiLib.Classes
{
    /// <summary>
    /// Вспомогательный класс с информацией о новой странице, для её создания
    /// </summary>
    public class Pages_PageCreate_Arguments
    {
        public string? assigneeUserName { get; set; }

        public string? body { get; set; } = null;

        public string? id { get; set; }

        public bool? isShowInToc { get; set; } = false;

        public string? ownerUserName { get; set; }

        public string? parentTocNodeId { get; set; } = null;


        public string? statusName { get; set; }

        public string? title { get; set; } = null;

        public string? tocNodeCaption { get; set; } = null;

        public int? tocNodeOrdinalNo { get; set; } = null;

        public string[]? indexKeywords { get; set; } = null;

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(Pages_PageCreate_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
