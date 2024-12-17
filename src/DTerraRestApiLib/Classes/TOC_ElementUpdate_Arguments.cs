using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DocTerraRestApiLib.Classes
{
    public class TOC_ElementUpdate_Arguments
    {
        public string? caption { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? isShowInToc { get; set; } = false;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ordinalNo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? parentId { get; set; } = null;

        public string? updatedFields { get; set; }

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, typeof(TOC_ElementUpdate_Arguments), CommonData.p_JsonSerializerOptions_Write);
        }
    }
}
